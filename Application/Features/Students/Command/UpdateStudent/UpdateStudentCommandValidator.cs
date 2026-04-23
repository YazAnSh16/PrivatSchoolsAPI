using FluentValidation;

namespace Application.Features.Students.Command.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Student name is required.");
            RuleFor(x => x.StudentBirthDate).NotEmpty().WithMessage("Student name is required.");
            RuleFor(x => x.StudentBirthPlace).NotEmpty().WithMessage("Student name is required.");
            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Student name is required.");
        }
    }
}
