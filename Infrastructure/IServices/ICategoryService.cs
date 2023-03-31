using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.IServices;

public interface ICategoryService
{
    Task<Response<List<GetCategoryDto>>> GetCategory();
    Task<Response<AddCategoryDto>> AddCategory(AddCategoryDto model);
}