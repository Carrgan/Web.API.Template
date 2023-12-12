using Application.Interfaces.MockService;
using Infrastructure.Share.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Share;

public static class ServiceExtension
{
    public static void AddInfrastructureShare(this IServiceCollection services)
    {
        services.AddTransient<IAppMockService, MockService>();
    } 
}