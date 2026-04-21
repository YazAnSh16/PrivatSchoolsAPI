using CQRS_LB.CQRS.Commands;
using CQRS_LB.Data;
using MediatR;

namespace CQRS_LB.CQRS.Handelers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        public UpdateStudentHandler(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;
        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _context.Students.Find(request.id);
            if (student == null)
            {
                return false;
            }
            else
            {
                student.Name = request.Student.StudentName;
                student.BirthPlace = request.Student.StudentBirthPlace;
                student.BirthDate = request.Student.StudentBirthDate;
                student.Address = request.Student.StudentAddress;
                student.FatherJob = request.Student.StudentFatherJob;
                student.MotherJob = request.Student.StudentMotherJob;
                student.PhoneNumber = request.Student.StudentPhoneNumber;
                student.MotherPhone = request.Student.StudentMotherPhone;
                student.FatherPhone = request.Student.StudentFatherPhone;
                student.HomePhone = request.Student.StudentHomePhone;
                student.Grade9 = request.Student.StudentGrade9;
                student.Grade11 = request.Student.StudentGrade11;
                if (request.Student.StudentProfilePicture != null)
                    student.ProfilePicture = request.Student.StudentProfilePicture;
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
