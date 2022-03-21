using OutfitCreator.SharedKernel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutfitCreator.SharedKernel.Interfaces
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity, IAggregateRoot;
        Task<List<T>> ListAsync<T>() where T : BaseEntity, IAggregateRoot;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task UpdateAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task DeleteAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
    }
}
