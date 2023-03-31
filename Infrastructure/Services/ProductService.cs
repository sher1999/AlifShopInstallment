using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Infrastructure.IServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService:IProductService
{
    private readonly AlifShopContext _context;
    private readonly IMapper _mapper;

    public ProductService(AlifShopContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetProductDto>>> GetProduct()
    {
        try
        {
            var result = await _context.Products.ToListAsync();
            var mapped = _mapper.Map<List<GetProductDto>>(result);
            return new Response<List<GetProductDto>>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<List<GetProductDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { ex.Message });
        }
    }
    public async Task<Response<AddProductDto>> AddProduct(AddProductDto model)
    {
        try
        {
            var existing =await _context.Products.FirstOrDefaultAsync(x=>x.ProductName == model.ProductName);
            if (existing == null)
            {
                var mapped = _mapper.Map<Product>(model);
                await _context.Products.AddAsync(mapped);
                await _context.SaveChangesAsync();
                model.Id=mapped.Id;
                return new Response<AddProductDto>(model);
           
            }
            return new Response<AddProductDto>(HttpStatusCode.BadRequest,
                new List<string>() { "A Product with such data already exists" });
        }
        catch (Exception ex)
        {
            return  new Response<AddProductDto>(HttpStatusCode.InternalServerError,new List<string>(){ex.Message});
        }
    }
}