

using Application.Contracts;
using Application.Exceptions;
using Domain.Commons;
using Infrastructure.Persistants;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }


        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await Table().AnyAsync(expression);    
        }

      
        public async Task<T> GetUserByIdAsync(Guid id)
        {
            if (!await AnyAsync(x=>x.Id == id))
            {
                throw new NotFoundException("کاربر یافت نشد");
            }

            return await Table().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(T entity)
        {
           
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public IQueryable<T> Table()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> TableTracking()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void UpdateRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().AttachRange(entities);
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
