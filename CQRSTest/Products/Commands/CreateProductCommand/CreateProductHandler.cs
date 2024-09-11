using AutoMapper;
using CQRSTest.Data;
using CQRSTest.DTOS;
using CQRSTest.Entities;
using CQRSTest.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTest.Products.Commands.CreateProductCommand;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, BaseResponse<ProductResponseDto>>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateProductHandler> _logger;

    public CreateProductHandler(ApplicationDbContext dbContext, IMapper mapper, ILogger<CreateProductHandler> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponse<ProductResponseDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var categoryId = request.CreateProductRequest.CategoryId;
        var category = await _dbContext.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == categoryId);

        if (category is null)
        {
            _logger.LogInformation("Couldn't find category with id " + request.CreateProductRequest.CategoryId);

            return new BaseResponse<ProductResponseDto>
            {
                IsSuccess = true,
                Message = "Category with id " + categoryId + " was not found"
            };
        }

        var product = _mapper.Map<Product>(request.CreateProductRequest);

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();

        var productResponse = _mapper.Map<ProductResponseDto>(product);

        _logger.LogInformation("Successfully added product " + product.Name + " to the database");

        return new BaseResponse<ProductResponseDto>
        {
            IsSuccess = true,
            Data = productResponse,
            Message = "Successfully created product"
        };
    }
}
