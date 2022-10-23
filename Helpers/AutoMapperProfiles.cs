using AutoMapper;
using Practica2.DTOs;
using Practica2.Entidades;

namespace Practica2.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<VehicleTypeCreacionDTO, VehicleType>();
            CreateMap<VehicleTypeDTO, VehicleType>();
        }
    }
}
