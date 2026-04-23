using Application.Features.Payments.Responses;

using MediatR;

namespace Application.Features.Payments.Queries.GetPaymentById
{
    public record GetPaymentsByIdQuery(int Id) : IRequest<List<PaymentDetailsResponse>>
    {

    }
}
