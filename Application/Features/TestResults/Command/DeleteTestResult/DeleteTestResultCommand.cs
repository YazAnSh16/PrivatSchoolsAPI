using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TestResults.Command.DeleteTestResult
{
    public record DeleteTestResultCommand(Guid Id) : IRequest<bool>
    {
    }

}
