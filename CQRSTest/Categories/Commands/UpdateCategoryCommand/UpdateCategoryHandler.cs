using AutoMapper;
using CQRSTest.Data;
using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTest.Categories.Commands.UpdateCategoryCommand;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, BaseResponse<CategoryResponseDto>>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateCategoryHandler> _logger;

    public UpdateCategoryHandler(ApplicationDbContext dbContext, IMapper mapper, ILogger<UpdateCategoryHandler> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponse<CategoryResponseDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == request.UpdateCategoryId);

        if (category == null)
        {
            return new BaseResponse<CategoryResponseDto>
            {
                IsSuccess = false,
                Message = "Category with ID " + request.UpdateCategoryId + " was not found"
            };
        }

        _mapper.Map(request.UpdateCategoryRequest, category);

        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync();

        var categoryResponse = _mapper.Map<CategoryResponseDto>(category);

        _logger.LogInformation("Succesffully updated category " + categoryResponse.Name + " in the database");

        return new BaseResponse<CategoryResponseDto>
        {
            IsSuccess = true,
            Data = categoryResponse,
            Message = "Successfully updated the category"
        };
    }
}
