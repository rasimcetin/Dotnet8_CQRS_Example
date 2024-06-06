using MediatR;

namespace Dotnet8_CQRS_Example.Cqrs.Commands;

public class UpdateProductCommand : IRequest<Guid>
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public UpdateProductCommand(Guid productId, string name, int quantity, decimal price)
    {
        ProductId = productId;
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}
