using Domain.Repositries.Common;

namespace Domain.Dtos.Event;

public class EventPagedRequestDto:PageRequest
{
    public bool? IsAvaliable { get; set; }
}
