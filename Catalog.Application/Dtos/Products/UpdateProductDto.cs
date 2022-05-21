using AutoMapper;
using Catalog.Application.Common.Mappings;
using Catalog.Domain.Entities;

namespace Catalog.Application.Dtos.Products
{
    public class UpdateProductDto : BaseProductDto, IMapFrom<Product>
    {
        public int? Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, Product>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((_, __, srcMember) => srcMember != null));
        }
    }
}