using AutoMapper;
using CQRSTest.Data;
using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTest.Products.Queries.GetProductByIdQuery;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, BaseResponse<ProductDetailsResponseDto>>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<GetProductByIdHandler> _logger;

    public GetProductByIdHandler(ApplicationDbContext dbContext, IMapper mapper, ILogger<GetProductByIdHandler> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponse<ProductDetailsResponseDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == request.GetProductById);

        if (product is null)
        {
            _logger.LogInformation("Couldn't find product with id " + request.GetProductById);

            return new BaseResponse<ProductDetailsResponseDto>
            {
                IsSuccess = true,
                Message = "Product with id " + request.GetProductById + " was not found"
            };
        }

        var productResponse = _mapper.Map<ProductDetailsResponseDto>(product);

        _logger.LogInformation("Successfully retrieved " + product.Name + " product details");

        return new BaseResponse<ProductDetailsResponseDto>
        {
            IsSuccess = true,
            Message = "Successfully retrieved all products",
            Data = productResponse
        };
    }
}
