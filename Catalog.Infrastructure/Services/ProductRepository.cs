using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Services
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly ApplicationContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ProductRepository(ApplicationContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> Create(Product entity)
        {
            var existingProduct = await _context.Products.Where(x => x.Name == entity.Name)
                                                    .SingleOrDefaultAsync();
            if (existingProduct != null)
                return existingProduct;

            return await base.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            await base.Delete(id);
            return true;
        }

        public async Task<IQueryable<Product>> FindAll()
        {
            return await base.FindAll();
        }

        public async Task<IQueryable<Product>> FindByCondition(Expression<Func<Product, bool>> expression)
        {
            return await base.FindByCondition(expression);
        }

        public async Task Update(Product entity)
        {
            var existingProduct = await _context.Products.AsNoTracking().Where(x => x.Id == entity.Id)
                                         .SingleOrDefaultAsync();
            if (existingProduct == null)
                throw new Exception("Product not found");

            await base.Update(entity);
        }

        public async Task<Product> FindById(int id)
        {
            return await base.FindById(id);
        }
    }
}