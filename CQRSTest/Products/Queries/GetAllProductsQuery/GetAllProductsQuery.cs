using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;

namespace CQRSTest.Products.Queries.GetAllProductsQuery;

public class GetAllProductsQuery : IRequest<BaseResponse<List<ProductResponseDto>>>
{
}
