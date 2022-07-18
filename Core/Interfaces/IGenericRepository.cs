using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity //basically allows only those who derive from BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpec(ISpecifications<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec);
        
    }
}