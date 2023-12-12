using MediatR;

namespace Application.Features.User.Commands.AddUser;

public class AddUserCommand : IRequest<string>
{
    public string Name { get; set; }
    public string Email { get; set; }
}