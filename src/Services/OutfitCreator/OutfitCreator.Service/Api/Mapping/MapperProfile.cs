using AutoMapper;
using Domain = OutfitCreator.Core.Domain;
using Model = OutfitCreator.Model;

namespace OutfitCreator.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Country, Model.Country>()
                .ReverseMap();

            CreateMap<Domain.Product, Model.Product>()
                .ReverseMap();

            CreateMap<Domain.ProductGroup, Model.ProductGroup>()
                .ReverseMap();

            CreateMap<Domain.ProductImage, Model.ProductImage>()
               .ReverseMap();

            CreateMap<Domain.ProductType, Model.ProductType>()
               .ReverseMap();
        }
    }
}
