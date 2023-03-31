using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddCustomerDto
{
    public  int Id { get; set; }
    [Required,MaxLength(50)]
    public string FirstName { get; set; }
    [Required,MaxLength(50)]
    public string LastName { get; set; }
    [Required,MaxLength(20)]
    public string PhoneNumber { get; set; }
    [Required,MaxLength(100)]
    public string Email { get; set; }
    [Required,MaxLength(50)]
    public string Address { get; set; }
}