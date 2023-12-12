using Domain.Entities.User;

namespace Application.Interfaces.MockService;

public interface IAppMockService
{
    IEnumerable<Users> GetAppUser(int numOfRecords = 250);
}