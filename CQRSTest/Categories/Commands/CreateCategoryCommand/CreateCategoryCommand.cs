using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;

namespace CQRSTest.Categories.Commands.CreateCategoryCommand;

public class CreateCategoryCommand : IRequest<BaseResponse<CategoryResponseDto>>
{
    public CategoryRequestDto CreateCategoryRequest { get; set; }
}
