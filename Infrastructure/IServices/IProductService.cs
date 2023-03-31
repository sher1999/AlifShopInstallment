using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.IServices;

public interface IProductService
{
    Task<Response<List<GetProductDto>>> GetProduct();
    Task<Response<AddProductDto>> AddProduct(AddProductDto model);
}