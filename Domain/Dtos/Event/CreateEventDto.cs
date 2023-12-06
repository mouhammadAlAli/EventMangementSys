namespace Domain.Dtos.Event;

public class CreateEventDto
{
    public int AvailableTickets { get; set; }
    public DateTime StartEventAt { get; set; }
    public List<EventTranslationDto> Translations { get; set; }
}
