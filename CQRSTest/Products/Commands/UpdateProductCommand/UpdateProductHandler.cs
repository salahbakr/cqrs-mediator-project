using AutoMapper;
using CQRSTest.Data;
using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTest.Products.Commands.UpdateProductCommand;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, BaseResponse<ProductResponseDto>>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateProductHandler> _logger;

    public UpdateProductHandler(ApplicationDbContext dbContext, IMapper mapper, ILogger<UpdateProductHandler> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponse<ProductResponseDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var categoryId = request.UpdateProductRequest.CategoryId;
        var productId = request.UpdateProductId;

        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

        if (category == null)
        {
            _logger.LogInformation("Couldn't find category with id " + categoryId);

            return new BaseResponse<ProductResponseDto>
            {
                IsSuccess = false,
                Message = "Category with ID " + categoryId + " was not found"
            };
        }

        var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

        if (product == null)
        {
            _logger.LogInformation("Couldn't find product with id " + productId);

            return new BaseResponse<ProductResponseDto>
            {
                IsSuccess = false,
                Message = "Product with ID " + productId + " was not found"
            };
        }

        _mapper.Map(request.UpdateProductRequest, product);

        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();

        var productResponse = _mapper.Map<ProductResponseDto>(product);

        _logger.LogInformation("Succesffully updated product " + productResponse.Name + " in the database");

        return new BaseResponse<ProductResponseDto>
        {
            IsSuccess = true,
            Data = productResponse,
            Message = "Successfully updated the product"
        };
    }
}
