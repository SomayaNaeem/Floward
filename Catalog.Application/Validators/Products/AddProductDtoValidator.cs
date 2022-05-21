using Catalog.Application.Dtos.Products;
using FluentValidation;

namespace Catalog.Application.Validators.Products
{
    public class AddProductDtoValidator : AbstractValidator<AddProductDto>
    {
        public AddProductDtoValidator()
        {
            RuleFor(e => e.Name).NotEmpty().NotNull()
               .Length(3, 50);

            RuleFor(e => e.Price).NotEmpty().NotNull();
        }
    }
}