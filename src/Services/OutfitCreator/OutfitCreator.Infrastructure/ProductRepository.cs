using Microsoft.EntityFrameworkCore;
using OutfitCreator.Core.Domain;
using OutfitCreator.Infrastructure;
using OutfitCreator.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace OutfitCreator.Core.Repository
{
    /// <summary>
    /// Ef core implementation for IProductRepository
    /// IProductRepository and Product domain is an abstruction layer and has no knowledge of ef infrastructure
    /// </summary>

    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext Context;
        private readonly IProductGroupRepository productGroupRepository;

        public ProductRepository(ApplicationDbContext context, IProductGroupRepository productGroupRepository)
        {
            this.Context = context;
            this.productGroupRepository = productGroupRepository;
        }
        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            try
            {
                await Context.Set<Product>().AddAsync(product);
                await Context.SaveChangesAsync();

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellation = default)
        {
            try
            {
                Context.Entry(product).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(Product product, CancellationToken cancellation = default)
        {
            try
            {
                var entity = Context.Set<Product>().Remove(product);
                await Context.SaveChangesAsync();
                return entity.State == EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await Context.Set<Product>().ToListAsync();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Identifier is not provided.");

            try
            {
                var response = await Context.Set<Product>().SingleOrDefaultAsync(e => e.Id == id);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetByCodeAsync(string code, Guid countryId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("Product ID is not provided.");
            if (countryId == Guid.Empty)
                throw new ArgumentNullException("Country ID is not provided.");

            try
            {
                var response = await Context.Set<Product>().FirstOrDefaultAsync(e => e.Code == code && e.CountryId == countryId);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> GetByGroupAsync(string[] webCategories, Guid? countryId, Gender gender, CancellationToken cancellationToken = default)
        {
            if (webCategories == null || webCategories.Length < 1)
                throw new ArgumentNullException("Web Categories are not provided.");
            if (countryId == Guid.Empty)
                throw new ArgumentNullException("Country ID is not provided.");

            try
            {
                var groups = Context.Set<ProductGroup>().Where(e => webCategories.Contains(e.WebCategory ?? ""));
                var g = await groups.Select(e=>e.Id).ToArrayAsync();

                Expression<Func<Product, bool>>? predicate = await SearchProductGroup(groups.ToArray(), countryId, gender);
                var response = Context.Set<Product>()
                                .Where(predicate.Compile());
                
                return response.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<Expression<Func<Product, bool>>> SearchProductGroup(ProductGroup[] groups, Guid? countryId, Gender gender)
        {
            var predicate = PredicateBuilder.False<Product>();

            if (groups == null || groups.Length < 1)
                return predicate;

            foreach (var group in groups)
                predicate = predicate.Or(x => x.ProductGroupId == group.Id);

            if (countryId != null)
            { 
                predicate = predicate.And(x=>x.CountryId == countryId);
            }

            predicate = predicate.And(x => x.Gender == gender);
            
            return await Task.FromResult( predicate );
        }
    }
}
