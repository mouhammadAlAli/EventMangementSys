using Application.EventUseCases.Commands;
using Application.EventUseCases.Quiries;
using Domain;
using Domain.Dtos.Event;
using Domain.Repositries.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventMangement.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Authorize(Roles = "Manager")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEventDto input)
    {
        await _mediator.Publish(new CreateEventCommand(input, 1));
        return Ok();
    }
    [HttpGet]
    public async Task<ActionResult<PageResult<EventDto>>> Get([FromQuery] EventPagedRequestDto pageRequest, [FromHeader(Name = "Accept-Language")] string acceptLanguage)
    {
        var result = await _mediator.Send(new GetEventsQuery(pageRequest));
        return Ok(result);

    }
    [Authorize(Roles = AppConsts.EventMangerRole)]
    [HttpPut("{eventId:int}")]
    public async Task<ActionResult> Update(int eventId, [FromBody] CreateEventDto createEventDto)
    {
        await _mediator.Publish(new UpdateEventCommand(new UpdateEventDto(eventId, createEventDto), 1));
        return Ok();
    }
    [Authorize(Roles = AppConsts.UserRole)]
    [HttpPut("Book{eventId:int}")]
    public async Task<IActionResult> Book(int eventId)
    {
        await _mediator.Publish(new BookForEventCommand(eventId));
        return Ok();
    }
    [Authorize(Roles = AppConsts.UserRole)]
    [HttpPut("CancelBook{eventId:int}")]
    public async Task<IActionResult> CancelBook(int eventId)
    {
        await _mediator.Publish(new CancelBookCommand(eventId));
        return Ok();
    }
    [Authorize(Roles = AppConsts.UserRole)]
    [HttpGet("GetMyEvents")]
    public async Task<ActionResult<List<EventDto>>> GetMyEvents([FromHeader(Name = "Accept-Language")] string acceptLanguage)
    {
        return Ok(await _mediator.Send(new GetMyEventsQuery()));
    }
}
