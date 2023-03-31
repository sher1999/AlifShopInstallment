using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddProductDto
{
    public  int Id { get; set; }
    [Required,MaxLength(100)]
    public string ProductName { get; set; }
    [Required]
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}