namespace CQRSTest.DTOS;

public class CategoryDetailsResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<ProductResponseDto>? Products { get; set; }
}
