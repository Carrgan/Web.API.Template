using Domain.Entities.User;

namespace Application.Interfaces.Repositories;

public interface IAppRepository
{
    Task AddUser(Users users);
    Task<Users?> GetUserByEmail(string email);
}