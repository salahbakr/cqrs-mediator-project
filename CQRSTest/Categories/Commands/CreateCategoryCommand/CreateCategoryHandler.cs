using AutoMapper;
using CQRSTest.Data;
using CQRSTest.DTOS;
using CQRSTest.Entities;
using CQRSTest.Responses;
using MediatR;

namespace CQRSTest.Categories.Commands.CreateCategoryCommand;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, BaseResponse<CategoryResponseDto>>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCategoryHandler> _logger;

    public CreateCategoryHandler(ApplicationDbContext dbContext, IMapper mapper, ILogger<CreateCategoryHandler> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponse<CategoryResponseDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request.CreateCategoryRequest);

        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();

        var categoryResponse = _mapper.Map<CategoryResponseDto>(category);

        _logger.LogInformation("Successfully added category " + category.Name + " to the database");

        return new BaseResponse<CategoryResponseDto>
        {
            IsSuccess = true,
            Data = categoryResponse,
            Message = "Successfully created category"
        };
    }
}
