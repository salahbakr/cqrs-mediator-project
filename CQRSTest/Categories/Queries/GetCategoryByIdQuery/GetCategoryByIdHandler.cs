using AutoMapper;
using CQRSTest.Data;
using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTest.Categories.Queries.GetCategoryByIdQuery;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, BaseResponse<CategoryDetailsResponseDto>>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<GetCategoryByIdHandler> _logger;

    public GetCategoryByIdHandler(ApplicationDbContext dbContext, IMapper mapper, ILogger<GetCategoryByIdHandler> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponse<CategoryDetailsResponseDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == request.GetCategoryById);

        if (category is null)
        {
            _logger.LogInformation("Couldn't find category with id " + request.GetCategoryById);

            return new BaseResponse<CategoryDetailsResponseDto>
            {
                IsSuccess = true,
                Message = "Category with id " + request.GetCategoryById + " was not found"
            };
        }

        var categoryResponse = _mapper.Map<CategoryDetailsResponseDto>(category);

        _logger.LogInformation("Successfully retrieved " + category.Name + " category details");

        return new BaseResponse<CategoryDetailsResponseDto>
        {
            IsSuccess = true,
            Message = "Successfully retrieved all categories",
            Data = categoryResponse
        };
    }
}