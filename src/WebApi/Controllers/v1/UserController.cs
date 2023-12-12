using Application.Features.User.Commands.AddUser;
using Application.Features.User.Queries.GetUserInfo;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Template.Web.Api.Controllers.v1;


[ApiVersion("1.0")]
public class UserController : BaseApiController
{
    [HttpGet("Get-User-By-Email")]
    [ProducesResponseType(typeof(GetUserResponse), 200)]
    public async Task<OkObjectResult> GetUserByEmail([FromQuery] GetUserInfoQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpPost("Add-User")]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<OkObjectResult> SetUser([FromBody] AddUserCommand user)
    {
        return Ok(await Mediator.Send(user));
    }
}