using Application.Interfaces.Repositories;
using Domain.DTOs;
using Mapster;
using MediatR;

namespace Application.Features.User.Queries.GetUserInfo;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, Domain.DTOs.GetUserResponse>
{
    private readonly IAppRepository _appRepository;

    public GetUserInfoQueryHandler(IAppRepository appRepository)
    {
        _appRepository = appRepository;
    }
    
    public async Task<GetUserResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await _appRepository.GetUserByEmail(request.Email);

        var getUserResponse = new GetUserResponse
        {
            User = user?.Adapt<Domain.DTOs.User>()
        };

        return getUserResponse;
    }
}