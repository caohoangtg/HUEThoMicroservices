using AutoMapper;
using Catalog.Application.Features.Catalogs.Commands;
using Catalog.Application.Features.Catalogs.Queries;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
