using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AlifShop.Controllers;

public class InstallmentController : ApiBaseController
{
   private readonly IInstallmentServise _installmentServise;

   public InstallmentController(IInstallmentServise installmentServise)
   {
      _installmentServise = installmentServise;
   }
   
   [HttpGet("GetInstallment")]
   public async Task<Response<GetTotalPrice>> Get( string productName, decimal price, string phoneNumber, int diapason)
   {
     return  await _installmentServise.GetInstallmentPlan(productName, price, phoneNumber, diapason);
   }
}