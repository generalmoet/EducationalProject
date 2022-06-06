using Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.PostgreSQL;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection
        services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("UserContext");
        services.AddDbContext<UserContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IUserDbContext>(provider =>
            provider.GetService<UserContext>());
        return services;
    }
}
