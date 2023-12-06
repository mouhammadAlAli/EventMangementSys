using Domain.Base;
using Domain.Users;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Events;

public class Event:AggregateEntity
{
    public Event()
    {
        Translations = new HashSet<EventTranslation>();
        Users = new HashSet<UserEvent>();
    }
    [Required]
    public DateTime StartEventAt { get; set; }
    [Required]
    public int AvailableTickets { get; set; }
    [Required]
    public int UserId { get; set; }
    [DefaultValue(false)]
    public bool IsActive { get; set; }
    public virtual User User { get; set; }
    public ICollection<EventTranslation> Translations { get; set; }
    public ICollection<UserEvent> Users { get; set; }

}
