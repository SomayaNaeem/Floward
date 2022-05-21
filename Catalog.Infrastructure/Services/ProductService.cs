using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Application.Dtos.Products;
using Catalog.Application.IntegrationEvents;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using EventBus.Abstractions;
using Microsoft.Extensions.Logging;

namespace Catalog.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private readonly IEventBus _eventBus;

        public ProductService(IProductRepository repository, IMapper mapper, ILogger<ProductService> logger, IEventBus eventBus)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _eventBus = eventBus;
        }

        public async Task<int> AddProduct(AddProductDto dto)
        {
            try
            {
                var mappedEntity = _mapper.Map<Product>(dto);
                // get image base64
                mappedEntity.Image = dto.ProductImage != null ? Helper.ConvertFileToBase64(dto.ProductImage) : String.Empty;

                var result = await _repository.Create(mappedEntity);

                #region Send email with the new product

                _eventBus.Publish(new SendEmailEvent()
                {
                    Subject = "New Arrival",
                    Email = "test@floward.com",
                    Message = "New product added: " + dto.Name + " with price: " + dto.Price
                });

                #endregion Send email with the new product

                return result.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return 0;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                await _repository.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<Product> FindProductById(int id)
        {
            try
            {
                var result = await _repository.FindById(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new Product();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var result = await _repository.FindAll();
                return result.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new List<Product>();
            }
        }

        public async Task<bool> UpdateProduct(UpdateProductDto dto)
        {
            try
            {
                var mappedEntity = _mapper.Map<Product>(dto);
                // get image base64
                mappedEntity.Image = dto.ProductImage != null ? Helper.ConvertFileToBase64(dto.ProductImage) : String.Empty;
                await _repository.Update(mappedEntity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }
    }
}