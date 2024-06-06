using Dotnet8_CQRS_Example.Data;
using Dotnet8_CQRS_Example.Dto;
using Dotnet8_CQRS_Example.Model;
using Dotnet8_CQRS_Example.Extensions;
using Microsoft.EntityFrameworkCore;

public class ProductRepository(ProductDbContext dbContext): IProductRepository
{
    public async Task CreateProduct(Product product)
    {
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteProduct(Guid id)
    {
         await dbContext.Products.Where(x => x.Id == id).ExecuteDeleteAsync();
         await dbContext.SaveChangesAsync();
    }

    public async Task<ProductDto> GetProductById(Guid id)
    {
        var product = await dbContext.Products.Where(x => x.Id == id).Select(p => p.ToProductDto()).FirstOrDefaultAsync();
        return product;
    }

    public Task<Product> GetProductEntityById(Guid id)
    {
        return dbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        return await dbContext.Products.Select(p => p.ToProductDto()).ToListAsync();
    }

    public async Task UpdateProduct(Product product)
    {
        dbContext.Entry(product).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }
}