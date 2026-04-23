using FluentValidation;

namespace Application.Features.Absence.Command.AddAbsence
{
    public class AddAbsenceCommandValidator : AbstractValidator<AddAbsenceCommand>
    {
        public AddAbsenceCommandValidator()
        {

            RuleFor(x => x.Result).NotEmpty().WithMessage("Result is required.");
            RuleFor(x => x.StudentId).GreaterThan(0).WithMessage("StudentId must be greater than 0.");
            RuleFor(x => x.AbsenceDate).NotEmpty().WithMessage("AbsenceDate is required.");
        }
    }
}
