using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.SeedData;

public class SeedData
{
    public static async Task Seed(AlifShopContext context)
    {
        if (context.Diapasons.Any()) return;
        var ranges = new List<Diapason>()
        {
            new Diapason(1, 3),
            new Diapason(2, 6),
            new Diapason(3, 9),
            new Diapason(4, 12),
            new Diapason(5, 18),
            new Diapason(6, 24),
        };
        context.Diapasons.AddRange(ranges);
        await context.SaveChangesAsync();
    }
}