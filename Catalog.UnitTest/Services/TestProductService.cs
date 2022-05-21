using AutoMapper;
using Catalog.Application.Interfaces;
using Catalog.Infrastructure.Services;
using Catalog.UnitTest.MockData;
using EventBus.Abstractions;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.UnitTest.Services
{
    public class TestProductService
    {
        private readonly IProductService _productService;
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<ProductService>> _logger;
        private readonly Mock<IEventBus> _eventBus;

        public TestProductService()
        {
            _productRepository = new Mock<IProductRepository>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<ProductService>>();
            _eventBus = new Mock<IEventBus>();
            _productService = new ProductService(_productRepository.Object, _mapper.Object, _logger.Object, _eventBus.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnProductById()
        {
            /// Arrange
            _productRepository.Setup(a => a.FindById(1)).ReturnsAsync(ProductMockData.GetProductById(1));

            /// Act
            var result = await _productService.FindProductById(1);

            /// Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnProductsCollection()
        {
            /// Arrange
            _productRepository.Setup(a => a.FindAll()).ReturnsAsync(ProductMockData.GetProducts().AsQueryable());

            /// Act
            var result = await _productService.GetAllProducts();

            /// Assert
            result.Count.ShouldBeGreaterThan(0);
        }
    }
}