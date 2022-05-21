using System.Linq.Expressions;

namespace Catalog.Application.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<T> FindById(int id);

        Task<IQueryable<T>> FindAll();

        Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression);

        Task<T> Create(T entity);

        Task Update(T entity);

        Task<bool> Delete(int id);
    }
}