using Application.Features.Students.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Students.Queries.GetStudentSummeryById
{
    public record GetStudentSummeryByIdQuery(Guid Id) : IRequest<StudentSummeryResponse>
    {
    }
}
