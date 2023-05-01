#nullable disable
using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Translations
{
    public class Translation<T, TID> : BaseEntity
    {
        public TID CoreId { get; set; }
        [ForeignKey(nameof(CoreId))]
        public T Core { get; set; }
        public string Language { get; set; }
    }
}
