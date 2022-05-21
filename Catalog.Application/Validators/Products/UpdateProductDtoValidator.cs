using Catalog.Application.Dtos.Products;
using FluentValidation;

namespace Catalog.Application.Validators.Products
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(e => e.Id).NotEmpty().NotNull();

            RuleFor(e => e.Name).NotEmpty().NotNull()
               .Length(3, 50);

            RuleFor(e => e.Price).NotEmpty().NotNull();
        }
    }
}