using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Diapason
{
    public int Id { get; set; }
    [Required]
    public int Number { get; set; }

    public Diapason()
    {
            
    }

    public Diapason(int id,int number)
    {
        Id = id;
        Number = number;
    }
}