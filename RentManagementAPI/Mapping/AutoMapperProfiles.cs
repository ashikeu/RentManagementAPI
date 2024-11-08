using AutoMapper;
using RentManagementAPI.Models.DTOs.Building;
using RentManagementAPI.Models.DTOs.Deposite;
using RentManagementAPI.Models.DTOs.Flat;
using RentManagementAPI.Models.DTOs.Floor;
using RentManagementAPI.Models.DTOs.IncomeExpense;
using RentManagementAPI.Models.DTOs.IncomeExpenseTransaction;
using RentManagementAPI.Models.DTOs.PropertyInfo;
using RentManagementAPI.Models.DTOs.Rent;
using RentManagementAPI.Models.DTOs.Tenant;
using RentManagementAPI.Models.DTOs.User;

namespace RentManagementAPI.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Floor, FloorDTO>().ReverseMap();            
            CreateMap<Flat, GetFlatDTO>().ReverseMap();
            CreateMap<FlatDTO, Flat>().ReverseMap();
            CreateMap<Tenant, GetTenantDTO>().ReverseMap();
            CreateMap<TenantDTO, Tenant>().ReverseMap();
            CreateMap<Rent, GetRentDTO>().ReverseMap();
            CreateMap<RentDTO, Rent>().ReverseMap();
            CreateMap<Deposite, GetDepositeDTO>().ReverseMap();
            CreateMap<AddDepositeDTO, Deposite>().ReverseMap();
            CreateMap<Building, GetBuildingDTO>().ReverseMap();
            CreateMap<BuildingDTO, Building>().ReverseMap();
            CreateMap<User, GetUserDTO>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<PropertyInfo, GetPropertyInfoDTO>().ReverseMap();
            CreateMap<PropertyInfoDTO, PropertyInfo>().ReverseMap();
            CreateMap<IncomeExpense, GetIncomeExpenseDTO>().ReverseMap();
            CreateMap<AddIncomeExpenseDTO, IncomeExpense>().ReverseMap();
            CreateMap<IncomeExpenseTransaction, GetIncomeExpenseTransactionDTO>().ReverseMap();
            CreateMap<AddIncomeExpenseTransactionDTO, IncomeExpenseTransaction>().ReverseMap();
        }
    }
}
