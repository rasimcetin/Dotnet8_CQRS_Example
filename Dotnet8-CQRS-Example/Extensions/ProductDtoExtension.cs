using Dotnet8_CQRS_Example.Dto;
using Dotnet8_CQRS_Example.Model;

namespace Dotnet8_CQRS_Example.Extensions;

public static class ProductDtoExtension
{
    public static Product ToProduct(this ProductDto productDto)
    {
        return new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            Quantity = productDto.Quantity
        };
    }

    public static Product ToProduct(this CreateProductDto productDto){
        return new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Quantity = productDto.Quantity
        };
    }

    public static ProductDto ToProductDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity
        };
    }
}