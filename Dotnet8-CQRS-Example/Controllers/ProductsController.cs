using Dotnet8_CQRS_Example.Cqrs.Commands;
using Dotnet8_CQRS_Example.Cqrs.Queries;
using Dotnet8_CQRS_Example.Data;
using Dotnet8_CQRS_Example.Dto;
using Dotnet8_CQRS_Example.Extensions;
using Dotnet8_CQRS_Example.Model;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet8_CQRS_Example;

[ApiController]
[Route("[controller]")]
public class ProductsController(IMediator mediator):ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        var products = await mediator.Send(new GetProductsQuery());
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(Guid id)
    {
        var product = await mediator.Send(new GetProductByIdQuery { ProductId = id });
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Post(CreateProductDto productDto)
    {
        var product = await mediator.Send(new CreateProductCommand(productDto.Name, productDto.Quantity, productDto.Price));
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, ProductDto productDto)
    {
        if (id != productDto.Id)
        {
            return BadRequest();
        }
        var product = await mediator.Send(new UpdateProductCommand(id, productDto.Name, productDto.Quantity, productDto.Price));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new DeleteProductCommand { ProductId = id });
        return NoContent();
    }
}
