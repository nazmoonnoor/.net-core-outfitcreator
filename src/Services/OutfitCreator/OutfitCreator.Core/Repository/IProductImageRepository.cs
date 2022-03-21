using OutfitCreator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OutfitCreator.Core.Repository
{
    /// <summary>
    /// Represents ProductImage repository functions
    /// </summary>
    public interface IProductImageRepository
    {
        Task<ProductImage> CreateAsync(ProductImage productImage, CancellationToken cancellationToken = default);
        Task<ProductImage> UpdateAsync(ProductImage productImage, CancellationToken cancellation = default);
        Task<bool> DeleteAsync(ProductImage productImage, CancellationToken cancellation = default);
        Task<ProductImage> GetByIdAsync(Guid id, CancellationToken cancellationToken = default); 
        Task<IList<ProductImage>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ProductImage> SearchImageAsync(Guid id, string resolution, string frame, CancellationToken cancellationToken = default);
    }
}
