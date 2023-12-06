using Domain.Base;
using Domain.Users;

namespace Domain.Events;

public class UserEvent:BaseEntity
{
    public int? UserId { get; set; }
    public virtual User User { get; set; }
    public int? EventId { get; set; }
    public virtual Event Event { get; set; }
}
