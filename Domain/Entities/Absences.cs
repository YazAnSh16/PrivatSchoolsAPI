namespace PrivatSchoolsAPI.Domain.Entities
{
    public class Absences
    {
        public Guid Id { get; set; }

        public bool Result { get; set; }

        public Guid StudentId { get; set; }

        public Student? Student { get; set; }

        public DateTime AbsenceDate { get; set; }
    }
}
