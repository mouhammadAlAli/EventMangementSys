using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Category
{
    public class UpdateCategoryDto:CreateCategoryDto
    {
        public Guid Id { get; set; }
    }
}
