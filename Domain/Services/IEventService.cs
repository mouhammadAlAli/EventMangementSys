using Domain.Dtos.Event;
using Domain.Events;
using Domain.Users;

namespace Domain.Services;

public interface IEventService:IGenaricSerivce<Event, EventDto, CreateEventDto , UpdateEventDto>
{
    Task Create(CreateEventDto createEventDto);
    Task Update(UpdateEventDto updateEventDto);
    Task Book(int eventId);
    Task CancelBook(int eventId);
    Task<List<EventDto>> GetMyEvent();


}
