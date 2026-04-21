namespace CQRS_LB.Data.Models
{
    public class Tests
    {
        public int Id { get; set; }

        public string TestSubject { get; set; }

        public string Result { get; set; }

        public DateTime TestDate { get; set; } = DateTime.Now;

        public string StudentId { get; set; }

        public Student Student { get; set; }
    }
}
