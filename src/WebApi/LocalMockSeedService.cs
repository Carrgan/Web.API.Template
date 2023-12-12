using Application.Interfaces.MockService;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Template.Web.Api;

public class LocalMockSeedService
{
    private readonly IAppMockService _appMockService;

    public LocalMockSeedService(IAppMockService appMockService)
    {
        _appMockService = appMockService;
    }

    public async Task Migration(IServiceProvider serviceScopeServiceProvider)
    {
        var appDbContext = serviceScopeServiceProvider.GetService<AppDbContext>();
        
        if (appDbContext.Database.IsSqlServer() && IsLocalDb(appDbContext))
        {
            var mockSeedServiceApp = new MockSeedServiceApp(_appMockService);
            await mockSeedServiceApp.MigrateAppDb(appDbContext);
        }
        
    }

    public bool IsLocalDb(DbContext dbContext)
    {
        var connectionString = dbContext.Database.GetConnectionString();
        return connectionString.Contains("localhost");
    }
    
}