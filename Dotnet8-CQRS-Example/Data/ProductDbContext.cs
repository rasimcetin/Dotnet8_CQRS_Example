using Dotnet8_CQRS_Example.Model;
using Microsoft.EntityFrameworkCore;

namespace Dotnet8_CQRS_Example.Data;

public class ProductDbContext: DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; } = null!;
}
