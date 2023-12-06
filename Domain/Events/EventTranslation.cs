using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Events;

public class EventTranslation:BaseEntity
{
    [Required]
    [MaxLength(30)]
    public string EventName { get; set; }
    [MaxLength(100)]
    public string EventDescription { get; set; }
    [Required]
    [MaxLength(2)]
    public string Language { get; set; }
    public int EventId { get; set; }
    public virtual Event Event { get; set; }
}
