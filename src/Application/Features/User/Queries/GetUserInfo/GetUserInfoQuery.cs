using MediatR;

namespace Application.Features.User.Queries.GetUserInfo;

public class GetUserInfoQuery: IRequest<Domain.DTOs.GetUserResponse>
{
    public string Email { get; set; }
}