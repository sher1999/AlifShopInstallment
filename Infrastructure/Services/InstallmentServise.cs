using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Data;
using Infrastructure.IServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class InstallmentServise:IInstallmentServise
{
    private readonly AlifShopContext _context;

    public InstallmentServise(AlifShopContext context)
    {
        _context = context;
    }
    public async Task<Response<GetTotalPrice>> GetInstallmentPlan(string productName, decimal price, string phoneNumber, int diapason)
    {
        int percent = 0;
        var product = await _context.Products.Where(x => x.ProductName== productName && x.Price==price).FirstOrDefaultAsync();
        if (product != null)
        {
            var user = await _context.Customers.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
            if (user != null)
            {
                var existing = await _context.Diapasons.Where(x => x.Number == diapason).FirstOrDefaultAsync();
                if (existing != null)
                {
                    var categoriId = await (_context.Products.Where(p => (p.ProductName == productName))
                        .Select(p => p.CategoryId)).FirstOrDefaultAsync();
                    percent = categoriId switch
                    {
                        1 when diapason == 12 => 3,
                        1 when diapason == 18 => 6,
                        1 when diapason == 24 => 9,
                        1 => 0,
                        2 when diapason == 18 => 4,
                        2 when diapason == 24 => 8,
                        2 => 0,
                        3 when diapason == 24 => 5,
                        3 => 0,
                        _ => percent
                    };
                    var result = new GetTotalPrice()
                    {
                        Product = productName,
                        Price = price,
                        Percent = percent,
                        MonthPayment = (price + (price * percent) / 100) / diapason,
                        TotalPrice = price + (price * percent) / 100
                    };
                    return new Response<GetTotalPrice>(result);
                    ;
                }
                return new Response<GetTotalPrice>(HttpStatusCode.BadRequest,
                    new List<string>() { "Such a diapason does not exist!" });
            }
            return new Response<GetTotalPrice>(HttpStatusCode.BadRequest,
                new List<string>() { "Register please!" });
        }
        return new Response<GetTotalPrice>(HttpStatusCode.BadRequest,
            new List<string>() { "Such a product (price) does not exist!" });
    }
}