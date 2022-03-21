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
    /// Ef core implementation for ICountryRepository
    /// ICountryRepository and Country domain is an abstruction layer and has no knowledge of ef infrastructure
    /// </summary>

    public class CountryRepository : ICountryRepository
    {
        private ApplicationDbContext Context;
        public CountryRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
        public async Task<Country> CreateAsync(Country country, CancellationToken cancellationToken = default)
        {
            try
            {
                await Context.Set<Country>().AddAsync(country);
                await Context.SaveChangesAsync();

                return country;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Country> UpdateAsync(Country country, CancellationToken cancellation = default)
        {
            try
            {
                Context.Entry(country).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return country;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(Country country, CancellationToken cancellation = default)
        {
            try
            {
                var entity = Context.Set<Country>().Remove(country);
                await Context.SaveChangesAsync();
                return entity.State == EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<Country>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await Context.Set<Country>().ToListAsync();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Country> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Identifier is not provided.");

            try
            {
                var response = await Context.Set<Country>().SingleOrDefaultAsync(e => e.Id == id);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Country> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("Country code is not provided.");

            try
            {
                var response = await Context.Set<Country>().SingleOrDefaultAsync(e => e.CountryCode == code);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
