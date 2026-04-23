using Application.Features.Payments.Responses;

using MediatR;

namespace Application.Features.Payments.Queries.GetPayments
{
    public record GetAllPaymentsQuery : IRequest<List<AllPaymentsDetailsResponse>>
    { }

}
