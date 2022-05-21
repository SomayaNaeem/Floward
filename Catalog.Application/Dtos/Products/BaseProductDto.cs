using Microsoft.AspNetCore.Http;

namespace Catalog.Application.Dtos.Products
{
    public class BaseProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; } = 0;
        public decimal Cost { get; set; } = 0;
        public IFormFile? ProductImage { get; set; }
    }
}