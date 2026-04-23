namespace Application.Features.Absence.Responses
{
    public class AbsenceDetailsRespones
    {
        public int Id { get; set; }

        public bool Result { get; set; }

        public int StudentId { get; set; }

        public DateTime AbsenceDate { get; set; }
    }
}
