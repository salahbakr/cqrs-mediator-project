using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;

namespace CQRSTest.Categories.Commands.UpdateCategoryCommand;

public class UpdateCategoryCommand : IRequest<BaseResponse<CategoryResponseDto>>
{
    public int UpdateCategoryId { get; set; }
    public CategoryRequestDto UpdateCategoryRequest { get; set; }
}
