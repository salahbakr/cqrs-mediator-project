using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;

namespace CQRSTest.Products.Queries.GetProductByIdQuery;

public class GetProductByIdQuery : IRequest<BaseResponse<ProductDetailsResponseDto>>
{
    public int GetProductById { get; set; }
}
