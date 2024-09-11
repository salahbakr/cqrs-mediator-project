using AutoMapper;

namespace CQRSTest.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        this.AddCategoryMapping();
        this.AddProductMapping();
    }
}
