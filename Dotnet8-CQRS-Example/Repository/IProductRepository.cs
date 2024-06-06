
using Dotnet8_CQRS_Example.Dto;
using Dotnet8_CQRS_Example.Model;

public interface IProductRepository
{
    Task CreateProduct(Product product);
    Task<ProductDto> GetProductById(Guid id);
    Task<Product> GetProductEntityById(Guid id);
    Task<IEnumerable<ProductDto>> GetProducts();
    Task UpdateProduct(Product product);
    Task DeleteProduct(Guid id);
}