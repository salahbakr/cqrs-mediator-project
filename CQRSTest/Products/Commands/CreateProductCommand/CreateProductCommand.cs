using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;

namespace CQRSTest.Products.Commands.CreateProductCommand;

public class CreateProductCommand : IRequest<BaseResponse<ProductResponseDto>>
{
    public ProductRequestDto CreateProductRequest { get; set; }
}
