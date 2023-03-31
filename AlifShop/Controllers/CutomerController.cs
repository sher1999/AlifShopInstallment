using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AlifShop.Controllers;

public class CutomerController:ApiBaseController
{
    private readonly ICustomerService _customerService;

    public CutomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet("GetCostomer")]
    public async Task<Response<List<GetCustomerDto>>> Get()
    {
        return await _customerService.GetCostomer();
    }

    [HttpPost("AddCostomer")]
    public async Task<Response<AddCustomerDto>> Add(AddCustomerDto model)
    {
        if (ModelState.IsValid)
        {
            return await _customerService.AddCostomer(model);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddCustomerDto>(HttpStatusCode.BadRequest, errors);
        }
    }
}