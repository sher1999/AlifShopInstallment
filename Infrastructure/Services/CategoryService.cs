using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Infrastructure.IServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CategoryService:ICategoryService
{
    private readonly AlifShopContext _context;
    private readonly IMapper _mapper;

    public CategoryService(AlifShopContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetCategoryDto>>> GetCategory()
    {
        try
        {
            var result = await _context.Categories.ToListAsync();
            var mapped = _mapper.Map<List<GetCategoryDto>>(result);
            return new Response<List<GetCategoryDto>>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<List<GetCategoryDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { ex.Message });
        }
    }
    public async Task<Response<AddCategoryDto>> AddCategory(AddCategoryDto model)
    {
        try
        {
            var existing =await _context.Categories.FirstOrDefaultAsync(x=>x.CategoryName == model.CategoryName);
            if (existing == null)
            {
                var mapped = _mapper.Map<Category>(model);
                await _context.Categories.AddAsync(mapped);
                await _context.SaveChangesAsync();
                model.Id=mapped.Id;
                return new Response<AddCategoryDto>(model);
           
            }
            return new Response<AddCategoryDto>(HttpStatusCode.BadRequest,
                new List<string>() { "A Category with such data already exists" });
        }
        catch (Exception ex)
        {
            return  new Response<AddCategoryDto>(HttpStatusCode.InternalServerError,new List<string>(){ex.Message});
        }
    }
}