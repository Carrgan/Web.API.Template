using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Users> Users { get; set; }
}