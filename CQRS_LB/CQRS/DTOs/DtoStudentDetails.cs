namespace CQRS_LB.CQRS.DTOs
{
    public class DtoStudentDetails
    {

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentBirthPlace { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public string? StudentAddress { get; set; }
        public string? StudentFatherJob { get; set; }
        public string? StudentMotherJob { get; set; }
        public string? StudentPhoneNumber { get; set; }
        public string? StudentMotherPhone { get; set; }
        public string? StudentFatherPhone { get; set; }
        public string? StudentHomePhone { get; set; }
        public string? StudentGrade9 { get; set; }
        public string? StudentGrade11 { get; set; }
        public byte[]? StudentProfilePicture { get; set; }
    }
}
