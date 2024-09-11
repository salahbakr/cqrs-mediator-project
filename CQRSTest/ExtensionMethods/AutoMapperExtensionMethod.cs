using CQRSTest.Mapping;

namespace CQRSTest.ExtensionMethods;

public static class AutoMapperExtensionMethod
{
    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfiles));

        return services;
    }
}
