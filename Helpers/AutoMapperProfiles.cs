using AutoMapper;
using Practica2.DTOs;
using Practica2.Entidades;

namespace Practica2.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<VehicleType, VehicleTypeDTO>().ReverseMap();
            CreateMap<VehicleTypeCreacionDTO, VehicleType>();
            CreateMap<VehiclePhoto, VehiclePhotoDTO>().ReverseMap();
            CreateMap<VehiclePhotoCreacionDTO, VehiclePhoto>();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<VehicleCreacionDTO, Vehicle>();
            CreateMap<History, HistoryDTO>().ReverseMap();
            CreateMap<HistoryCreacionDTO, History>();
            CreateMap<Detail, DetailDTO>().ReverseMap();
            CreateMap<DetailCreacionDTO, Detail>();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<BrandCreacionDTO, Brand>();
        }
    }
}
