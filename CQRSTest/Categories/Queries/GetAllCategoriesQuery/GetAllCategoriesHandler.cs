using AutoMapper;
using CQRSTest.Data;
using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTest.Categories.Queries.GetAllCategoriesQuery;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, BaseResponse<List<CategoryResponseDto>>>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllCategoriesHandler> _logger;

    public GetAllCategoriesHandler(ApplicationDbContext dbContext, IMapper mapper, ILogger<GetAllCategoriesHandler> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponse<List<CategoryResponseDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _dbContext.Categories.ToListAsync();

        var categoriesResponse = _mapper.Map<List<CategoryResponseDto>>(categories);

        _logger.LogInformation("Successfully retrieved " + categories.Count + " categories");

        return new BaseResponse<List<CategoryResponseDto>>
        {
            IsSuccess = true,
            Message = "Successfully retrieved all categories",
            Data = categoriesResponse
        };
    }
}
