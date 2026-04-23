using FluentValidation;

namespace Application.Features.Payments.Command.UpdatePayment
{
    internal class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
    {
        public UpdatePaymentCommandValidator()
        {

            RuleFor(x => x.Amount)
                    .GreaterThan(0).WithMessage("Amount must be greater than 0.");
            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("TotalAmount must be greater than 0.");
            RuleFor(x => x.PaymentDate)
               .LessThanOrEqualTo(DateTime.Now).WithMessage("PaymentDate cannot be in the future.");
        }
    }
}
