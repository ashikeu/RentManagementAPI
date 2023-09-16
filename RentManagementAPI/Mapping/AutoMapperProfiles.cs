using AutoMapper;
using RentManagementAPI.Models.DTOs.Deposite;
using RentManagementAPI.Models.DTOs.Flat;
using RentManagementAPI.Models.DTOs.Floor;
using RentManagementAPI.Models.DTOs.Rent;
using RentManagementAPI.Models.DTOs.Tenant;

namespace RentManagementAPI.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Floor, GetFloorDTO>().ReverseMap();
            CreateMap<AddFloorDTO, Floor>().ReverseMap();
            CreateMap<Flat, GetFlatDTO>().ReverseMap();
            CreateMap<AddFlatDTO, Flat>().ReverseMap();
            CreateMap<Tenant, GetTenantDTO>().ReverseMap();
            CreateMap<AddTenantDTO, Tenant>().ReverseMap();
            CreateMap<Rent, GetRentDTO>().ReverseMap();
            CreateMap<AddRentDTO, Rent>().ReverseMap();
            CreateMap<Deposite, GetDepositeDTO>().ReverseMap();
            CreateMap<AddDepositeDTO, Deposite>().ReverseMap();
        }
    }
}
