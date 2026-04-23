
using Application.Features.Students.Responses;
using MediatR;
namespace Application.Features.Students.Command.AddStudent
{
    public record AddStudentCommand(string StudentName,
    string StudentBirthPlace,
    DateTime StudentBirthDate,
    string? StudentAddress,
    string? StudentFatherJob,
    string? StudentMotherJob,
    string? StudentPhoneNumber,
    string? StudentMotherPhone,
    string? StudentFatherPhone,
    string? StudentHomePhone,
    string? StudentGrade9,
    string? StudentGrade11,
    string? ProfileImageUrl) : IRequest<StudentDetailsResponse>
    {

    }
}
