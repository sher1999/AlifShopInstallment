using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AlifShop.Controllers;

public class ProductController:ApiBaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet("GetProduct")]
    public async Task<Response<List<GetProductDto>>> Get()
    {
        return await _productService.GetProduct();
    }

    [HttpPost("AddProduct")]
    public async Task<Response<AddProductDto>> Add(AddProductDto model)
    {
        if (ModelState.IsValid)
        {
            return await _productService.AddProduct(model);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddProductDto>(HttpStatusCode.BadRequest, errors);
        }
    }
}