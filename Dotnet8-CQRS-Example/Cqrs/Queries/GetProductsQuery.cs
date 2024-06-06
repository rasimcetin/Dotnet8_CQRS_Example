using Dotnet8_CQRS_Example.Dto;
using MediatR;

namespace Dotnet8_CQRS_Example.Cqrs.Queries;

public class GetProductsQuery:IRequest<IEnumerable<ProductDto>>
{

}
