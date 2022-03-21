using Microsoft.EntityFrameworkCore;
using OutfitCreator.Core.Domain;
using OutfitCreator.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OutfitCreator.Core.Repository
{
    /// <summary>
    /// Ef core implementation for IProductGroupRepository
    /// IProductGroupRepository and ProductGroup domain is an abstruction layer and has no knowledge of ef infrastructure
    /// </summary>

    public class ProductGroupRepository : IProductGroupRepository
    {
        private ApplicationDbContext Context;
        public ProductGroupRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
        public async Task<ProductGroup> CreateAsync(ProductGroup productGroup, CancellationToken cancellationToken = default)
        {
            try
            {
                await Context.Set<ProductGroup>().AddAsync(productGroup);
                await Context.SaveChangesAsync();

                return productGroup;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductGroup> UpdateAsync(ProductGroup productGroup, CancellationToken cancellation = default)
        {
            try
            {
                Context.Entry(productGroup).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return productGroup;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(ProductGroup productGroup, CancellationToken cancellation = default)
        {
            try
            {
                var entity = Context.Set<ProductGroup>().Remove(productGroup);
                await Context.SaveChangesAsync();
                return entity.State == EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<ProductGroup>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await Context.Set<ProductGroup>().ToListAsync();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductGroup> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Identifier is not provided.");

            try
            {
                var response = await Context.Set<ProductGroup>().SingleOrDefaultAsync(e => e.Id == id);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}