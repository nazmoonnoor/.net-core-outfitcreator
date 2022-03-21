using OutfitCreator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OutfitCreator.Core.Repository
{
    /// <summary>
    /// Represents ProductGroup repository functions
    /// </summary>
    public interface IProductGroupRepository
    {
        Task<ProductGroup> CreateAsync(ProductGroup productGroup, CancellationToken cancellationToken = default);
        Task<ProductGroup> UpdateAsync(ProductGroup productGroup, CancellationToken cancellation = default);
        Task<bool> DeleteAsync(ProductGroup productGroup, CancellationToken cancellation = default);
        Task<ProductGroup> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IList<ProductGroup>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
