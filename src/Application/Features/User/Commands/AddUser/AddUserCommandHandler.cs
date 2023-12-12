using Mapster;
using MediatR;
using Application.Interfaces.Repositories;

namespace Application.Features.User.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, string>
{

    private readonly IAppRepository _appRepository;

    public AddUserCommandHandler(IAppRepository appRepository)
    {
        _appRepository = appRepository;
    }
    
    public async Task<string> Handle(AddUserCommand user, CancellationToken cancellationToken)
    {
        var entityUser = user.Adapt<Domain.Entities.User.Users>();
        await _appRepository.AddUser(entityUser);
        // TODO: Exception handler
        return "Task.FromResult(\"Good to go\")";
    }
}