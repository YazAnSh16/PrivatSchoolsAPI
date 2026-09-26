using Application.Common;
using Application.Features.Absence.Command.AddAbsence;
using Application.Features.Absence.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PrivatSchoolsAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TestResults.Command.AddTestResults
{
    public class AddTestResultCommandHandler(IAppDbContext context) : IRequestHandler<AddTestResultCommand, bool>

    {

        public async Task<bool> Handle(AddTestResultCommand request, CancellationToken cancellationToken)
        {
            // Create domain entity using fully-qualified name to avoid namespace/type ambiguity
            var testResult = new TestResult

            {
                Id = Guid.NewGuid(),
                TestDate = request.TestDate,
                Result = request.Result,
                StudentId = request.SudentId,
                TestSubject = request.TestSubject
            };

            await context.TestResults.AddAsync(testResult);
            var result = await context.SaveChangesAsync(cancellationToken);

            if(result <= 0)
            {
                throw new Exception("Failed to add test result.");
            }
            else 
            {
                return true;
            }
        }

    }
}