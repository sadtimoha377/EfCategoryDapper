using AutoMapper;
using EfOne.Dtos;
using EfOne.Models;

namespace EfOne.Profiles;

public class ProductDetailedProfile : Profile
{
    public ProductDetailedProfile()
    {
        CreateMap<Product, ProductDetailedDto>()
            .ForMember(
                x => x.CategoryName,
                opt => opt.MapFrom(x => x.Category.Name))
            .ForMember(
                x => x.BrandName,
                opt => opt.MapFrom(x => x.Brand.Name));
    }
}