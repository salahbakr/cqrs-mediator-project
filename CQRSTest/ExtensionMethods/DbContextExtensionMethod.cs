using CQRSTest.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRSTest.ExtensionMethods;

public static class DbContextExtensionMethod
{
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
