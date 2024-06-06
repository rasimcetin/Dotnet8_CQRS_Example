
using MediatR;

namespace Dotnet8_CQRS_Example.Cqrs.Commands;

public class DeleteProductCommand: IRequest<Guid>
{
    public Guid ProductId { get; set; }
}
