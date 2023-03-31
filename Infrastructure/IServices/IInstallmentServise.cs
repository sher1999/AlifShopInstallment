using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.IServices;

public interface IInstallmentServise
{
    Task<Response<GetTotalPrice>> GetInstallmentPlan(string productName, decimal price, string phoneNumber, int diapason);
}