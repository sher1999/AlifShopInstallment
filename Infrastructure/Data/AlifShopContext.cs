using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AlifShopContext:DbContext
{
    public AlifShopContext(DbContextOptions<AlifShopContext> options) : base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Diapason> Diapasons { get; set; }
}