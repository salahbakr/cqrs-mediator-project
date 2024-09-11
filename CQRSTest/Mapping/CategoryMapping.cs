using CQRSTest.DTOS;
using CQRSTest.Entities;

namespace CQRSTest.Mapping;

public static class CategoryMapping
{
    public static void AddCategoryMapping(this MappingProfiles map)
    {
        map.CreateMap<CategoryRequestDto, Category>();
        map.CreateMap<Category, CategoryResponseDto>();
        map.CreateMap<Category, CategoryDetailsResponseDto>();
    }
}
