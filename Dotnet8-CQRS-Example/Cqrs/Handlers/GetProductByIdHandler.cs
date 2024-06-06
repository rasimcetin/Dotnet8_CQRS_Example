using Dotnet8_CQRS_Example.Cqrs.Queries;
using Dotnet8_CQRS_Example.Dto;
using MediatR;

namespace Dotnet8_CQRS_Example.Cqrs.Handlers;

public class GetProductByIdHandler(IProductRepository productRepository):IRequestHandler<GetProductByIdQuery,ProductDto>
{
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await productRepository.GetProductById(request.ProductId);
    }
}   