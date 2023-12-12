using Domain.Entities.User;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;

namespace Infrastructure.Persistence.Repositories.AppRepository;

public class AppRepository : IAppRepository
{
    private readonly AppDbContext _appDbContext;

    public AppRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddUser(Users users)
    {
        await _appDbContext.AddAsync(users);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Users?> GetUserByEmail(string email)
    {
        var user = await _appDbContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();
        return user;
    }
}