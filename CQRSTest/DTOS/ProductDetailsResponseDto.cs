using CQRSTest.Entities;

namespace CQRSTest.DTOS;

public class ProductDetailsResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

    public CategoryResponseDto Category { get; set; }
}
