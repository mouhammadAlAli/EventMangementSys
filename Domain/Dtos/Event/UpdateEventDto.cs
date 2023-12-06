namespace Domain.Dtos.Event;

public class UpdateEventDto:CreateEventDto
{
    public int Id { get; set; }
    public UpdateEventDto(int Id,CreateEventDto createEventDto)
    {
        this.Id = Id;
        this.StartEventAt = createEventDto.StartEventAt;
        this.AvailableTickets = createEventDto.AvailableTickets;
        this.Translations = createEventDto.Translations;
    }
}
