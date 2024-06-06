using Dotnet8_CQRS_Example.Cqrs.Commands;
using Dotnet8_CQRS_Example.Dto;
using Dotnet8_CQRS_Example.Extensions;
using Dotnet8_CQRS_Example.Model;
using MediatR;

namespace Dotnet8_CQRS_Example.Cqrs.Handlers;

public class CreateProductHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(){
            Name = request.Name,
            Price = request.Price,
            Quantity = request.Quantity
        };
        await productRepository.CreateProduct(product);
        return product.ToProductDto();
    }
}