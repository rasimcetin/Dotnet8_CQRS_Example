using Dotnet8_CQRS_Example.Cqrs.Commands;
using MediatR;

namespace Dotnet8_CQRS_Example.Cqrs.Handlers;

public class UpdateProductHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, Guid>
{
    public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductEntityById(request.ProductId);

        if (product == null)
        {
            return default;
        }

        product.Name = request.Name;
        product.Price = request.Price;
        product.Quantity = request.Quantity;
        await productRepository.UpdateProduct(product);
        return product.Id;
    }
}