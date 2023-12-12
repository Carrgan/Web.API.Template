using Bogus;
using Domain.Entities.User;

namespace Infrastructure.Share.Configuration;

public class UserMockConfig : Faker<Users>
{
    public UserMockConfig()
    {
        RuleFor(o => o.Name, f => f.Name.FullName());
        RuleFor(o => o.Email, f => f.Internet.Email());
    }
}