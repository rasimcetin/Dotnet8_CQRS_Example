using Dotnet8_CQRS_Example.Dto;
using MediatR;

namespace Dotnet8_CQRS_Example.Cqrs.Commands;

public class CreateProductCommand:IRequest<ProductDto>
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public CreateProductCommand(string name, int quantity, decimal price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}
