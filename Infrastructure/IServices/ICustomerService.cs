using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.IServices;

public interface ICustomerService
{
    Task<Response<List<GetCustomerDto>>> GetCostomer();
    Task<Response<AddCustomerDto>> AddCostomer(AddCustomerDto model);
}