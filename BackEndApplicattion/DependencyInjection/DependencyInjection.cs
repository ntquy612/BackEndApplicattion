using BackEndApplicattion.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEndApplicattion.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DBContext>(option =>
        {
            option.UseNpgsql(connectionString);
        });

        return services;
    }
}
