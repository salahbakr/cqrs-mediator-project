using CQRSTest.DTOS;
using CQRSTest.Entities;

namespace CQRSTest.Mapping;

public static class ProductMapping
{
    public static void AddProductMapping(this MappingProfiles map)
    {
        map.CreateMap<ProductRequestDto, Product>();
        map.CreateMap<Product, ProductResponseDto>();
        map.CreateMap<Product, ProductDetailsResponseDto>();
    }
}
