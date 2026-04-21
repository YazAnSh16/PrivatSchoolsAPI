using CQRS_LB.CQRS.Commands;
using CQRS_LB.CQRS.DTOs;
using CQRS_LB.Data;
using CQRS_LB.Data.Models;
using MediatR;

namespace CQRS_LB.CQRS.Handelers
{
    public class AddNewStudentHandler : IRequestHandler<AddNewStudentCommand, DtoStudentDetails>
    {
        public AddNewStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;



        async Task<DtoStudentDetails> IRequestHandler<AddNewStudentCommand, DtoStudentDetails>.Handle(AddNewStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = new()
            {

                Name = request.Student.StudentName,
                BirthDate = request.Student.StudentBirthDate,
                BirthPlace = request.Student.StudentBirthPlace,
                Address = request.Student.StudentAddress,
                FatherJob = request.Student.StudentFatherJob,
                MotherJob = request.Student.StudentMotherJob,
                PhoneNumber = request.Student.StudentPhoneNumber,
                MotherPhone = request.Student.StudentMotherPhone,
                FatherPhone = request.Student.StudentFatherPhone,
                HomePhone = request.Student.StudentHomePhone,
                Grade9 = request.Student.StudentGrade9,
                Grade11 = request.Student.StudentGrade11,
                ProfilePicture = request.Student.StudentProfilePicture
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return new DtoStudentDetails
            {
                StudentId = student.Id,
                StudentName = student.Name,
                StudentBirthPlace = student.BirthPlace,
                StudentBirthDate = student.BirthDate,
                StudentAddress = student.Address,
                StudentFatherJob = student.FatherJob,
                StudentMotherJob = student.MotherJob,
                StudentPhoneNumber = student.PhoneNumber,
                StudentMotherPhone = student.MotherPhone,
                StudentFatherPhone = student.FatherPhone,
                StudentHomePhone = student.HomePhone,
                StudentGrade9 = student.Grade9,
                StudentGrade11 = student.Grade11,
                StudentProfilePicture = student.ProfilePicture
            };
        }



    }
}
