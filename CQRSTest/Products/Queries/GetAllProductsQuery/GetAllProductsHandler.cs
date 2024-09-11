using AutoMapper;
using CQRSTest.Data;
using CQRSTest.DTOS;
using CQRSTest.Products.Queries.GetProductByIdQuery;
using CQRSTest.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTest.Products.Queries.GetAllProductsQuery;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, BaseResponse<List<ProductResponseDto>>>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<GetProductByIdHandler> _logger;

    public GetAllProductsHandler(ApplicationDbContext dbContext, IMapper mapper, ILogger<GetProductByIdHandler> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponse<List<ProductResponseDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _dbContext.Categories.ToListAsync();

        var productsResponse = _mapper.Map<List<ProductResponseDto>>(products);

        _logger.LogInformation("Successfully retrieved " + products.Count + " products");

        return new BaseResponse<List<ProductResponseDto>>
        {
            IsSuccess = true,
            Message = "Successfully retrieved all products",
            Data = productsResponse
        };
    }
}
