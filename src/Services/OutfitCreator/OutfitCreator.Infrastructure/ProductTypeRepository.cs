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
    /// Ef core implementation for IProductTypeRepository
    /// IProductTypeRepository and ProductType domain is an abstruction layer and has no knowledge of ef infrastructure
    /// </summary>

    public class ProductTypeRepository : IProductTypeRepository
    {
        private ApplicationDbContext Context;
        public ProductTypeRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
        public async Task<ProductType> CreateAsync(ProductType productType, CancellationToken cancellationToken = default)
        {
            try
            {
                await Context.Set<ProductType>().AddAsync(productType);
                await Context.SaveChangesAsync();

                return productType;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductType> UpdateAsync(ProductType productType, CancellationToken cancellation = default)
        {
            try
            {
                Context.Entry(productType).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return productType;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(ProductType productType, CancellationToken cancellation = default)
        {
            try
            {
                var entity = Context.Set<ProductType>().Remove(productType);
                await Context.SaveChangesAsync();
                return entity.State == EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<ProductType>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await Context.Set<ProductType>().ToListAsync();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductType> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Identifier is not provided.");

            try
            {
                var response = await Context.Set<ProductType>().SingleOrDefaultAsync(e => e.Id == id);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}