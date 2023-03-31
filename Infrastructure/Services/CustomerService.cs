using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Infrastructure.IServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CustomerService:ICustomerService
{
    private readonly AlifShopContext _context;
    private readonly IMapper _mapper;

    public CustomerService(AlifShopContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetCustomerDto>>> GetCostomer()
    {
        try
        {
            var result = await _context.Customers.ToListAsync();
            var mapped = _mapper.Map<List<GetCustomerDto>>(result);
            return new Response<List<GetCustomerDto>>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<List<GetCustomerDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { ex.Message });
        }
    }
    public async Task<Response<AddCustomerDto>> AddCostomer(AddCustomerDto model)
    {
        try
        {
            var existing =await _context.Customers.FirstOrDefaultAsync(x=>x.PhoneNumber == model.PhoneNumber);
            if (existing == null)
            {
                var mapped = _mapper.Map<Customer>(model);
                await _context.Customers.AddAsync(mapped);
                await _context.SaveChangesAsync();
                model.Id=mapped.Id;
                return new Response<AddCustomerDto>(model);
           
            }
            return new Response<AddCustomerDto>(HttpStatusCode.BadRequest,
                new List<string>() { "A Phone Number with such data already exists" });
        }
        catch (Exception ex)
        {
            return  new Response<AddCustomerDto>(HttpStatusCode.InternalServerError,new List<string>(){ex.Message});
        }
    }
}