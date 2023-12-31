

using Domain.Commons;
using System.Linq.Expressions;

namespace Application.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetUserByIdAsync(Guid id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRangeAsync(IEnumerable<T> entities);
        IQueryable<T> Table();
        IQueryable<T> TableTracking();

        Task<bool> SaveChangesAsync();


    }
}
