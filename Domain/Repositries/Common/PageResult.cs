using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositries.Common
{
    public class PageResult<T>
    {
        public int TotalRecords { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
