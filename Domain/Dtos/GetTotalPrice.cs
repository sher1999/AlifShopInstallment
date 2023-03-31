namespace Domain.Dtos;

public class GetTotalPrice
{
    public  string Product { get; set; }
    public decimal Price { get; set; }
    public int Percent { get; set; }
    public decimal MonthPayment { get; set; }
    public decimal TotalPrice { get; set; }
}