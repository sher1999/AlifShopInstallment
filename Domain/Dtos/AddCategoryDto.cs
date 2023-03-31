using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddCategoryDto
{
    public int Id { get; set; } 
    [Required,MaxLength(100)]
    public string CategoryName { get; set; }
}