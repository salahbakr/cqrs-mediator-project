using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;

namespace CQRSTest.Categories.Commands.DeleteCategoryCommand;

public class DeleteCategoryCommand : IRequest<BaseResponse<CategoryResponseDto>>
{
    public int DeleteCategoryId { get; set; }
}
