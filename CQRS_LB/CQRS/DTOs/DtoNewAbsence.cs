namespace CQRS_LB.CQRS.DTOs
{
    public class DtoNewAbsence
    {
        public int Id { get; set; }

        public bool Result { get; set; }

        public int StudentId { get; set; }

        public DateTime AbsenceDate { get; set; }
    }
}
