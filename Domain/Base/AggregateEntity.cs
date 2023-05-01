using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Domain.Base
{
    public class AggregateEntity : BaseEntity
    {
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdateOnUtc { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
