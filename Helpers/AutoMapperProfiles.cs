using AutoMapper;
using Practica3.DTOs;
using Practica3.Entidades;

namespace Practica3.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductType, ProductTypeDTO>().ReverseMap();
            CreateMap<ProductTypeCreacionDTO, ProductType>();
            CreateMap<ProductPhoto, ProductPhotoDTO>().ReverseMap();
            CreateMap<ProductPhotoCreacionDTO, ProductPhoto>();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductCreacionDTO, Product>();
            CreateMap<History, HistoryDTO>().ReverseMap();
            CreateMap<HistoryCreacionDTO, History>();
            CreateMap<Detail, DetailDTO>().ReverseMap();
            CreateMap<DetailCreacionDTO, Detail>();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<BrandCreacionDTO, Brand>();
        }
    }
}
