namespace CQRS_LB.Data.Models
{
    public class Absence
    {
        public int Id { get; set; }

        public bool Result { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public DateTime AbsenceDate { get; set; }
    }
}
