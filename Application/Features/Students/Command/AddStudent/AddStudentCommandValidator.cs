using FluentValidation;

namespace Application.Features.Students.Command.AddStudent
{
    public class AddStudentCommandValidator : FluentValidation.AbstractValidator<AddStudentCommand>
    {
        public AddStudentCommandValidator()
        {
            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Student name is required.");
            RuleFor(x => x.StudentBirthDate).NotEmpty().WithMessage("Student name is required.");
            RuleFor(x => x.StudentBirthPlace).NotEmpty().WithMessage("Student name is required.");
            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Student name is required.");

        }
    }
}
