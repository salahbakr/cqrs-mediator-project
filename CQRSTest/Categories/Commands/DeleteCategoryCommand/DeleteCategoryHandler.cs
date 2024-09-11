using AutoMapper;
using CQRSTest.Data;
using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTest.Categories.Commands.DeleteCategoryCommand;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, BaseResponse<CategoryResponseDto>>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteCategoryHandler> _logger;

    public DeleteCategoryHandler(ApplicationDbContext dbContext, IMapper mapper, ILogger<DeleteCategoryHandler> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponse<CategoryResponseDto>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == request.DeleteCategoryId);

        if (category == null)
        {
            return new BaseResponse<CategoryResponseDto>
            {
                IsSuccess = false,
                Message = "Category with ID " + request.DeleteCategoryId + " was not found"
            };
        }

        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
        
        var categoryResponse = _mapper.Map<CategoryResponseDto>(category);

        _logger.LogInformation("Succesffully deleted category " + categoryResponse.Name + " from the database");

        return new BaseResponse<CategoryResponseDto>
        {
            IsSuccess = true,
            Data = categoryResponse,
            Message = "Successfully delete the category"
        };
    }
}
