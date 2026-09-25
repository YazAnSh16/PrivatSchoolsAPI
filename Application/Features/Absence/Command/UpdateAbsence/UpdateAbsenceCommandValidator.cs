using FluentValidation;

namespace Application.Features.Absence.Command.UpdateAbsence
{
    public class UpdateAbsenceCommandValidator : AbstractValidator<UpdateAbsenceCommand>
    {
        public UpdateAbsenceCommandValidator()
        {
            
            RuleFor(x => x.AbsenceDate).NotEmpty().WithMessage("AbsenceDate is required.");
        }

    }
}
