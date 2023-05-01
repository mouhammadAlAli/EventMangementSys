using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryUseCase.Command;
    public record DeleteCategoryCommand(Guid CategoryId):INotification;

