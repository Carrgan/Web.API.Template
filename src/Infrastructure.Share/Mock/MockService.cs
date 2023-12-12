using Application.Interfaces.MockService;
using Domain.Entities.User;
using Infrastructure.Share.Configuration;

namespace Infrastructure.Share.Mock;

public class MockService : IAppMockService
{
    public IEnumerable<Users> GetAppUser(int numOfRecords = 250)
    {
        var generator = new UserMockConfig();
        return generator.Generate(numOfRecords);
    }
}