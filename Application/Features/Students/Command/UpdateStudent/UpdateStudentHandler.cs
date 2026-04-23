using Application.Common;

using MediatR;

namespace Application.Features.Students.Command.UpdateStudent
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        public UpdateStudentHandler(IAppDbContext context)
        {
            _context = context;
        }
        private readonly IAppDbContext _context;
        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _context.Students.Find(request.Id);
            if (student == null)
            {
                return false;
            }
            else
            {
                student.Name = request.StudentName;
                student.BirthPlace = request.StudentBirthPlace;
                student.BirthDate = request.StudentBirthDate;
                student.Address = request.StudentAddress;
                student.FatherJob = request.StudentFatherJob;
                student.MotherJob = request.StudentMotherJob;
                student.PhoneNumber = request.StudentPhoneNumber;
                student.MotherPhone = request.StudentMotherPhone;
                student.FatherPhone = request.StudentFatherPhone;
                student.HomePhone = request.StudentHomePhone;
                student.Grade9 = request.StudentGrade9;
                student.Grade11 = request.StudentGrade11;
                student.ProfileImageUrl = request.ProfileImageUrl;
                _context.Students.Update(student);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}
