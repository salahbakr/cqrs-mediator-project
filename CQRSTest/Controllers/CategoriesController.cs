using CQRSTest.Categories.Commands.CreateCategoryCommand;
using CQRSTest.Categories.Commands.DeleteCategoryCommand;
using CQRSTest.Categories.Commands.UpdateCategoryCommand;
using CQRSTest.Categories.Queries.GetAllCategoriesQuery;
using CQRSTest.Categories.Queries.GetCategoryByIdQuery;
using CQRSTest.DTOS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSTest.Controllers;

public class CategoriesController : BaseController
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryResponseDto>>> GetAllCategoriesAsync()
    {
        var request = new GetAllCategoriesQuery();

        return Ok(await _mediator.Send(request));
    }

    [HttpGet("id={id}")]
    public async Task<ActionResult<List<CategoryResponseDto>>> GetCategoryByIdAsync(int id)
    {
        var request = new GetCategoryByIdQuery 
        {
            GetCategoryById = id 
        };

        return Ok(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<List<CategoryResponseDto>>> AddCategoryAsync(CategoryRequestDto categoryRequest)
    {
        var request = new CreateCategoryCommand
        {
            CreateCategoryRequest = categoryRequest
        };

        return Ok(await _mediator.Send(request));
    }

    [HttpPut("id={id}")]
    public async Task<ActionResult<List<CategoryResponseDto>>> UpdateCategoryAsync(int id, CategoryRequestDto categoryRequest)
    {
        var request = new UpdateCategoryCommand
        {
            UpdateCategoryId = id,
            UpdateCategoryRequest = categoryRequest
        };

        return Ok(await _mediator.Send(request));
    }

    [HttpDelete("id={id}")]
    public async Task<ActionResult<List<CategoryResponseDto>>> DeleteCategoryAsync(int id)
    {
        var request = new DeleteCategoryCommand
        {
            DeleteCategoryId = id
        };

        return Ok(await _mediator.Send(request));
    }
}
