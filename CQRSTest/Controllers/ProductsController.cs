using CQRSTest.Products.Commands.CreateProductCommand;
using CQRSTest.Products.Commands.DeleteProductCommand;
using CQRSTest.Products.Commands.UpdateProductCommand;
using CQRSTest.Products.Queries.GetAllProductsQuery;
using CQRSTest.Products.Queries.GetProductByIdQuery;
using CQRSTest.DTOS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSTest.Controllers;

public class ProductsController : BaseController
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductResponseDto>>> GetAllProductsAsync()
    {
        var request = new GetAllProductsQuery();

        return Ok(await _mediator.Send(request));
    }

    [HttpGet("id={id}")]
    public async Task<ActionResult<List<ProductResponseDto>>> GetProductByIdAsync(int id)
    {
        var request = new GetProductByIdQuery
        {
            GetProductById = id
        };

        return Ok(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<List<ProductResponseDto>>> AddProductAsync(ProductRequestDto categoryRequest)
    {
        var request = new CreateProductCommand
        {
            CreateProductRequest = categoryRequest
        };

        return Ok(await _mediator.Send(request));
    }

    [HttpPut("id={id}")]
    public async Task<ActionResult<List<ProductResponseDto>>> UpdateProductAsync(int id, ProductRequestDto categoryRequest)
    {
        var request = new UpdateProductCommand
        {
            UpdateProductId = id,
            UpdateProductRequest = categoryRequest
        };

        return Ok(await _mediator.Send(request));
    }

    [HttpDelete("id={id}")]
    public async Task<ActionResult<List<ProductResponseDto>>> DeleteProductAsync(int id)
    {
        var request = new DeleteProductCommand
        {
            DeleteProductId = id
        };

        return Ok(await _mediator.Send(request));
    }
}
