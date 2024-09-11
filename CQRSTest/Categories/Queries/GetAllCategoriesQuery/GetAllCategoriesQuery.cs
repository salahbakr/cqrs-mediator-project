using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;

namespace CQRSTest.Categories.Queries.GetAllCategoriesQuery;

public class GetAllCategoriesQuery : IRequest<BaseResponse<List<CategoryResponseDto>>>
{
}
