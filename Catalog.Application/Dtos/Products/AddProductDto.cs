using AutoMapper;
using Catalog.Application.Common.Mappings;
using Catalog.Domain.Entities;

namespace Catalog.Application.Dtos.Products
{
    public class AddProductDto : BaseProductDto, IMapFrom<Product>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddProductDto, Product>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((_, __, srcMember) => srcMember != null));
        }
    }
}