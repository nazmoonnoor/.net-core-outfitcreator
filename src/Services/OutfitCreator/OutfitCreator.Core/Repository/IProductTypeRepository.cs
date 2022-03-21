using OutfitCreator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OutfitCreator.Core.Repository
{
    /// <summary>
    /// Represents ProductType repository functions
    /// </summary>
    public interface IProductTypeRepository
    {
        Task<ProductType> CreateAsync(ProductType productType, CancellationToken cancellationToken = default);
        Task<ProductType> UpdateAsync(ProductType productType, CancellationToken cancellation = default);
        Task<bool> DeleteAsync(ProductType productType, CancellationToken cancellation = default);
        Task<ProductType> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IList<ProductType>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
