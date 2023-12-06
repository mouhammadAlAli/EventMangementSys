using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Event;

public class EventTranslationDto
{
    [Required]
    public string EventName { get; set; }
    [Required]
    public string EventDescription { get; set; }
    [Required]
    public string Language { get; set; }
}
