using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category
{ 
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public string CategoryName { get; set; }
    public List<Product> Products { get; set; }
}