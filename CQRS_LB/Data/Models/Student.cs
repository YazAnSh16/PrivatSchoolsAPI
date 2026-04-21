namespace CQRS_LB.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public string? FatherJob { get; set; }
        public string? MotherJob { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MotherPhone { get; set; }
        public string? FatherPhone { get; set; }
        public string? HomePhone { get; set; }
        public string? Grade9 { get; set; }
        public string? Grade11 { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Payments> Payments { get; set; } = new List<Payments>();
        public List<Absence> Absences { get; set; } = new List<Absence>();

        public List<Tests> Tests { get; set; } = new List<Tests>();
    }
}
