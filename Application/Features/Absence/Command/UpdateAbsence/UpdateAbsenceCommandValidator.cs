using FluentValidation;

namespace Application.Features.Absence.Command.UpdateAbsence
{
    public class UpdateAbsenceCommandValidator : AbstractValidator<UpdateAbsenceCommand>
    {
        public UpdateAbsenceCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Result).NotEmpty().WithMessage("Result is required.");
            RuleFor(x => x.AbsenceDate).NotEmpty().WithMessage("AbsenceDate is required.");
        }

    }
}
