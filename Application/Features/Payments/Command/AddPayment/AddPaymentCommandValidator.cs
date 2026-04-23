using FluentValidation;

namespace Application.Features.Payments.Command.AddPayment
{
    public class AddPaymentCommandValidator : AbstractValidator<AddPaymentCommand>
    {
        public AddPaymentCommandValidator()
        {
            //     public int StudentId { get; set; }
            //public decimal Amount { get; set; }

            //public decimal TotalAmount { get; set; }
            RuleFor(x => x.StudentId).NotNull().WithMessage("StudentId is required.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");
            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("TotalAmount must be greater than 0.");
        }
    }
}
