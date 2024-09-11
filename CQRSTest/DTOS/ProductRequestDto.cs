using CQRSTest.Entities;

namespace CQRSTest.DTOS;

public class ProductRequestDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}
