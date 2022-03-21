using OutfitCreator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OutfitCreator.Core.Repository
{
    /// <summary>
    /// Represents Product repository functions
    /// </summary>
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
        Task<Product> UpdateAsync(Product product, CancellationToken cancellation = default);
        Task<bool> DeleteAsync(Product product, CancellationToken cancellation = default);
        Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IList<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Product> GetByCodeAsync(string code, Guid country, CancellationToken cancellationToken = default);
        Task<List<Product>> GetByGroupAsync(string[] webCategories, Guid? countryId, Gender gender, CancellationToken cancellationToken = default);
    }
}
