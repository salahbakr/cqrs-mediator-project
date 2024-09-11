using AutoMapper;
using CQRSTest.Data;
using CQRSTest.DTOS;
using CQRSTest.Products.Commands.UpdateProductCommand;
using CQRSTest.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTest.Products.Commands.DeleteProductCommand;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, BaseResponse<ProductResponseDto>>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteProductHandler> _logger;

    public DeleteProductHandler(ApplicationDbContext dbContext, IMapper mapper, ILogger<DeleteProductHandler> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponse<ProductResponseDto>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == request.DeleteProductId);

        if (product == null)
        {
            return new BaseResponse<ProductResponseDto>
            {
                IsSuccess = false,
                Message = "Product with ID " + request.DeleteProductId + " was not found"
            };
        }

        _dbContext.Categories.Remove(product);
        await _dbContext.SaveChangesAsync();

        var productResponse = _mapper.Map<ProductResponseDto>(product);

        _logger.LogInformation("Succesffully deleted product " + productResponse.Name + " from the database");

        return new BaseResponse<ProductResponseDto>
        {
            IsSuccess = true,
            Data = productResponse,
            Message = "Successfully delete the product"
        };
    }
}
