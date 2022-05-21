using Catalog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Services
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ApplicationContext _context;

        protected RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<T>> FindAll() => _context.Set<T>().AsNoTracking();

        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression).AsNoTracking();

        public async Task<T> Create(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await FindById(id);

            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<T> FindById(int id) => _context.Set<T>().Find(id);
    }
}