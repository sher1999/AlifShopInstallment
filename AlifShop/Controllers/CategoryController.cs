using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AlifShop.Controllers;

public class CategoryController:ApiBaseController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet("GetCategory")]
    public async Task<Response<List<GetCategoryDto>>> Get()
    {
        return await _categoryService.GetCategory();
    }

    [HttpPost("AddCategory")]
    public async Task<Response<AddCategoryDto>> Add(AddCategoryDto model)
    {
        if (ModelState.IsValid)
        {
            return await _categoryService.AddCategory(model);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddCategoryDto>(HttpStatusCode.BadRequest, errors);
        }
    }
}