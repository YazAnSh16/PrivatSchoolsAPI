namespace Application.Features.Absence.Responses
{
    public class AbsenceDetailsRespones
    {
        public Guid Id { get; set; }

        public bool Result { get; set; }

        public Guid StudentId { get; set; }

        public DateTime AbsenceDate { get; set; }
    }
}
