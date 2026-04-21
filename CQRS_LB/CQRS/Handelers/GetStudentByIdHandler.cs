using CQRS_LB.CQRS.DTOs;
using CQRS_LB.CQRS.Queries;
using CQRS_LB.Data;

namespace CQRS_LB.CQRS.Handelers
{
    public class GetStudentByIdHandler : MediatR.IRequestHandler<Queries.GetStudentByIdQuery, DTOs.DtoStudentDetails>
    {
        public GetStudentByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public Task<DtoStudentDetails> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == request.Id);
            if (student == null)
            {
                return Task.FromResult<DtoStudentDetails>(null);
            }
            else
            {
                DtoStudentDetails studentDetails = new DtoStudentDetails
                {
                    StudentId = student.Id,
                    StudentName = student.Name,
                    StudentBirthDate = student.BirthDate,
                    StudentBirthPlace = student.BirthPlace,
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
                return Task.FromResult(studentDetails);
            }
        }
    }
}
