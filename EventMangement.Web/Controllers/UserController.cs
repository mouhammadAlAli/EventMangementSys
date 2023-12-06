using Application.UserUseCases.Commands;
using Application.UserUseCases.Queries;
using Domain.Dtos.Users;
using Domain.Repositries.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventMangement.Web.Controllers;
[Route("api/users")]
[ApiController]
public class UserController:ControllerBase
{
    private IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Create([FromBody] CreateUserDto input)
    {
        await _mediator.Publish(new RegisterCommand(input));
        return Ok();
    }
    [HttpGet]
    public async Task<ActionResult<PageResult<UserDto>>> Get([FromQuery] PageRequest pageRequest)
    {
        return Ok(await _mediator.Send(new GetUsersQuery(pageRequest)));
    }
}
