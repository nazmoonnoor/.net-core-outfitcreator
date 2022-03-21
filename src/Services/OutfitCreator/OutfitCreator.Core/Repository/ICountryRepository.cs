using OutfitCreator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OutfitCreator.Core.Repository
{
    /// <summary>
    /// Represents Country repository functions
    /// </summary>
    public interface ICountryRepository
    {
        Task<Country> CreateAsync(Country country, CancellationToken cancellationToken = default);
        Task<Country> UpdateAsync(Country country, CancellationToken cancellation = default);
        Task<bool> DeleteAsync(Country country, CancellationToken cancellation = default);
        Task<Country> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IList<Country>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Country> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
    }
}
