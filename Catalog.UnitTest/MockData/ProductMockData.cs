using Catalog.Application.Dtos.Products;
using Catalog.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Catalog.UnitTest.MockData
{
    public class ProductMockData
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>{
             new Product{
                 Id = 1,
                Name="Mobile phone",
                Cost=20000,
                Price=10000,
                Image=""
             },
             new Product{
                 Id = 2,
                 Name = "Labtop",
                 Price = 30000,
                 Cost=30000,
                 Image=""
             },
             new Product{
                 Id = 3,
                 Name = "TV",
                 Price = 10000,
                 Cost=10000,
                 Image=""
             }
         };
        }

        public static Product GetProductById(int id)
        {
            return
             new Product
             {
                 Id = 1,
                 Name = "Mobile phone",
                 Cost = 20000,
                 Price = 10000,
                 Image = ""
             };
        }

        public static List<Product> GetEmptyProducts()
        {
            return new List<Product>();
        }

        public static AddProductDto NewProduct()
        {
            //Setup mock file using a memory stream
            byte[] bytes = Encoding.UTF8.GetBytes("hello world");

            var file = new FormFile(
                 baseStream: new MemoryStream(bytes),
                 baseStreamOffset: 0,
                 length: bytes.Length,
                 name: "Data",
                 fileName: "test"
             )
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png"
            };
            return new AddProductDto
            {
                Name = "New Product4",
                Price = 500,
                Cost = 200,
                ProductImage = file
            };
        }

        public static UpdateProductDto UpdateProduct()
        {
            return new UpdateProductDto
            {
                Id = 1,
                Name = "Updated Product",
                Price = 1000,
                Cost = 200
            };
        }
    }
}