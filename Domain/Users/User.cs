using Domain.Base;
using Domain.Events;
using Domain.Roles;
using System.ComponentModel.DataAnnotations;

namespace Domain.Users;

public class User:BaseEntity
{
    public User()
    {
        Events = new HashSet<UserEvent>();
    }
    [Required]
    [StringLength(30)]
    public string Name { get; set; }
    [EmailAddress]
    [Required]
    [StringLength(30)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public int? RoleId { get; set; }
    public virtual Role Role { get; set; }
    public ICollection<UserEvent> Events { get; set; }
}
