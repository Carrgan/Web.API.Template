using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories.AppRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Repositories;

namespace Infrastructure.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AppDatabase")));
        
        # region Repositories
        services.AddTransient<IAppRepository, AppRepository>();
        # endregion
    }
}