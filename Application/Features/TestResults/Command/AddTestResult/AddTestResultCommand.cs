using MediatR;
using PrivatSchoolsAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TestResults.Command.AddTestResults
{
    public record AddTestResultCommand(Guid SudentId , TestSubject TestSubject , string Result , DateTime TestDate) : IRequest<bool>
    {
    }
}

