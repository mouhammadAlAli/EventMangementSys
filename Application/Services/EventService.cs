using Application.Exceptions;
using AutoMapper;
using Domain;
using Domain.Authontication;
using Domain.Dtos.Event;
using Domain.Events;
using Domain.Exceptions;
using Domain.Repositries;
using Domain.Services;

namespace Application.Services;

internal class EventService : GenaricSerivce<Event, EventDto, CreateEventDto, UpdateEventDto>, IEventService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthonticateUserSerivce _authonticateUserSerivce;
    public EventService(IRepository<Event> repository, IMapper mapper, IAuthonticateUserSerivce authonticateUserSerivce) : base(repository, mapper)
    {
        _authonticateUserSerivce = authonticateUserSerivce;
    }

    public async Task Book(int eventId)
    {
        var userId = _authonticateUserSerivce.GetUserId();
        if(userId == 0)
            throw new ForbiddenException();
        var entity = await _repository.FirstOrDefualt(x => x.Id == eventId, x => x.Users);
        if(entity.AvailableTickets == 0)
        {
            throw new ForbiddenException("Not Avaliable");
        }
        if(entity.Users.Any(x=>x.UserId == userId))
        {
            throw new ForbiddenException("You already book for this event");
        }
        entity.Users.Add(new UserEvent { UserId = userId, EventId = eventId });
        entity.AvailableTickets--;
        _repository.Update(entity);
    }

    public async Task CancelBook(int eventId)
    {
        var userId = _authonticateUserSerivce.GetUserId();
        if (userId == 0)
            throw new ForbiddenException();
        var entity = await _repository.FirstOrDefualt(x => x.Id == eventId, x => x.Users);
        if (!entity.Users.Any(x => x.UserId == userId))
        {
            throw new ForbiddenException("You did not book for this event");
        }
        var user = entity.Users.First(x => x.UserId == userId);
        entity.Users.Remove(user);
        entity.AvailableTickets ++ ;
        _repository.Update(entity);
    }

    public async Task Create(CreateEventDto createEventDto)
    {
        var userRole = _authonticateUserSerivce.GetUserRole();
        if(userRole != AppConsts.EventMangerRole) 
        {
            throw new ForbiddenException();
        }
        var entity = _mapper.Map<Event>(createEventDto);
        entity.UserId = _authonticateUserSerivce.GetUserId();
        await _repository.Create(entity);
    }

    public async Task<List<EventDto>> GetMyEvent()
    {
        var userId = _authonticateUserSerivce.GetUserId();
        var result = await _repository.GetAll(x => x.Users.Select(x => x.UserId).Contains(userId),x=>x.Translations);
        var resultDto = _mapper.Map<List<EventDto>>(result);
        return resultDto;

    }

    public async Task Update(UpdateEventDto updateEventDto)
    {
        var userId = _authonticateUserSerivce.GetUserId();
        var entity = await _repository.FirstOrDefualt(x => x.Id == updateEventDto.Id,x=>x.Translations);
        entity.Translations.Clear();
        if(entity == null) 
        {
            throw new NotFoundException(nameof(Event),updateEventDto.Id.ToString());
        }
        if(entity.UserId != userId)
        {
            throw new ForbiddenException();
        }
        entity = _mapper.Map(updateEventDto, entity);
        _repository.Update(entity);
    }
}
