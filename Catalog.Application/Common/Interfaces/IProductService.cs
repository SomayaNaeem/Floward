using Catalog.Application.Dtos.Products;
using Catalog.Domain.Entities;

namespace Catalog.Application.Interfaces
{
    public interface IProductService
    {
        Task<int> AddProduct(AddProductDto dto);

        Task<bool> UpdateProduct(UpdateProductDto dto);

        Task<bool> DeleteProduct(int id);

        Task<Product> FindProductById(int id);

        Task<List<Product>> GetAllProducts();
    }
}