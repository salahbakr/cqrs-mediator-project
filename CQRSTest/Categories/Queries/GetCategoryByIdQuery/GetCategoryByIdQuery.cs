using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;

namespace CQRSTest.Categories.Queries.GetCategoryByIdQuery;

public class GetCategoryByIdQuery : IRequest<BaseResponse<CategoryDetailsResponseDto>>
{
    public int GetCategoryById { get; set; }
}
