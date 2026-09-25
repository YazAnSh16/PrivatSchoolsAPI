using FluentValidation;

namespace Application.Features.Absence.Command.AddAbsence
{
    public class AddAbsenceCommandValidator : AbstractValidator<AddAbsenceCommand>
    {
        public AddAbsenceCommandValidator()
        {

            
            RuleFor(x => x.AbsenceDate).NotEmpty().WithMessage("AbsenceDate is required.");
        }
    }
}
