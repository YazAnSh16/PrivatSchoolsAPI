namespace CQRS_LB.CQRS.DTOs
{
    public class DtoUpdateAbsence
    {
        public bool Result { get; set; }

        public int Id { get; set; }
        public DateTime AbsenceDate { get; set; }
    }
}
