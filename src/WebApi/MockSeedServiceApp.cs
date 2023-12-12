using Application.Interfaces.MockService;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Template.Web.Api;

public class MockSeedServiceApp
{
    private readonly IAppMockService _appMockService;

    public MockSeedServiceApp(IAppMockService appMockService)
    {
        _appMockService = appMockService;
    }

    public async Task MigrateAppDb(AppDbContext appDbContext)
    {
        await appDbContext.Database.MigrateAsync();

        if (appDbContext.Users.Count() < 250)
        {
            await appDbContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [Users]");
            foreach (var user in _appMockService.GetAppUser())
            {
                await appDbContext.Users.AddAsync(user);
            }
            await appDbContext.SaveChangesAsync();
        }
    }
}