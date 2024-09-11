using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;

namespace CQRSTest.Products.Commands.DeleteProductCommand;

public class DeleteProductCommand : IRequest<BaseResponse<ProductResponseDto>>
{
    public int DeleteProductId { get; set; }
}
