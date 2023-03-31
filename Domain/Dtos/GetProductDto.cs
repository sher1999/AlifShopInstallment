using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class GetProductDto
{
    public  int Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

}