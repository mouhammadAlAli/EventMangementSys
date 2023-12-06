namespace Domain.Dtos.Event;

public class EventDto
{
    public int Id { get; set; }
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public int AvailableTickets { get; set; }
    public bool IsActive { get; set; }
}
