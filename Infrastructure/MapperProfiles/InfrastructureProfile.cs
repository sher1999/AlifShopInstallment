using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.MapperProfiles;

public class InfrastructureProfile:Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Category,GetCategoryDto>();
        CreateMap<AddCategoryDto,Category>();
        CreateMap<Product,GetProductDto>();
        CreateMap<AddProductDto,Product>();
        CreateMap<Customer,GetCustomerDto>();
        CreateMap<AddCustomerDto,Customer>();
    }
    
}