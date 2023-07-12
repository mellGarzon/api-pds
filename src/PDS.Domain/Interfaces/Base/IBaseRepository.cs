using System;
namespace PDS.Domain.Interfaces.RepositoryInterfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(long id);

        Task<List<T>> GetAllAsync();

        void Add(T t);

        bool Delete(int id);

        void Update(T t);
    }
}

