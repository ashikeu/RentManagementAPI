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
            CreateMap<Building, GetBuildingDTO>().ReverseMap();
            CreateMap<AddBuildingDTO, Building>().ReverseMap();
            CreateMap<User, GetUserDTO>().ReverseMap();
            CreateMap<AddUserDTO, User>().ReverseMap();
            CreateMap<PropertyInfo, GetPropertyInfoDTO>().ReverseMap();
            CreateMap<AddPropertyInfoDTO, PropertyInfo>().ReverseMap();
            CreateMap<IncomeExpense, GetIncomeExpenseDTO>().ReverseMap();
            CreateMap<AddIncomeExpenseDTO, IncomeExpense>().ReverseMap();
            CreateMap<IncomeExpenseTransaction, GetIncomeExpenseTransactionDTO>().ReverseMap();
            CreateMap<AddIncomeExpenseTransactionDTO, IncomeExpenseTransaction>().ReverseMap();
        }
    }
}
