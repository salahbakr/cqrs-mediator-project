using AutoMapper;
using CQRSTest.Data;
using CQRSTest.DTOS;
using CQRSTest.Responses;
using MediatR;

namespace CQRSTest.Products.Commands.UpdateProductCommand;

public class UpdateProductCommand : IRequest<BaseResponse<ProductResponseDto>>
{
    public int UpdateProductId { get; set; }
    public ProductRequestDto UpdateProductRequest { get; set; }
}
