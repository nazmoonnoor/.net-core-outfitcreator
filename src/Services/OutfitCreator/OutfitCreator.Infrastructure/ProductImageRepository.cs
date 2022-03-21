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
    /// Ef core implementation for IProductImageRepository
    /// IProductImageRepository and ProductImage domain is an abstruction layer and has no knowledge of ef infrastructure
    /// </summary>

    public class ProductImageRepository : IProductImageRepository
    {
        private ApplicationDbContext Context;
        public ProductImageRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
        public async Task<ProductImage> CreateAsync(ProductImage productImage, CancellationToken cancellationToken = default)
        {
            try
            {
                await Context.Set<ProductImage>().AddAsync(productImage);
                await Context.SaveChangesAsync();

                return productImage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductImage> UpdateAsync(ProductImage productImage, CancellationToken cancellation = default)
        {
            try
            {
                Context.Entry(productImage).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return productImage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(ProductImage productImage, CancellationToken cancellation = default)
        {
            try
            {
                var entity = Context.Set<ProductImage>().Remove(productImage);
                await Context.SaveChangesAsync();
                return entity.State == EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<ProductImage>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await Context.Set<ProductImage>().ToListAsync();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductImage> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Identifier is not provided.");

            try
            {
                var response = await Context.Set<ProductImage>().SingleOrDefaultAsync(e => e.Id == id);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductImage> SearchImageAsync(Guid id, string resolution, string frame, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Identifier is not provided.");

            try
            {
                var response = await Context.Set<ProductImage>().SingleOrDefaultAsync(e => e.Id == id && e.Resolution == resolution && e.Frame == frame);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}