using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Roles;

public class Role:AggregateEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
}
