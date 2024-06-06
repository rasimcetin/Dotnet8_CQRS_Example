using Dotnet8_CQRS_Example.Cqrs.Commands;
using MediatR;

namespace Dotnet8_CQRS_Example.Cqrs.Handlers;

public class DeletePrpoductHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand, Guid>
{
    public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductEntityById(request.ProductId);
        if (product == null)
        {
            return default;
        }
        await productRepository.DeleteProduct(request.ProductId);
        return request.ProductId;
    }
}