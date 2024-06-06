using Dotnet8_CQRS_Example.Cqrs.Queries;
using Dotnet8_CQRS_Example.Dto;
using MediatR;

namespace Dotnet8_CQRS_Example.Cqrs.Handlers;

public class GetProductsHandler(IProductRepository productRepository) : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await productRepository.GetProducts();
    }
}