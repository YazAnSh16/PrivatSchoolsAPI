namespace CQRS_LB.CQRS.DTOs
{
    public class AddAbsenceRequest
    {


        public bool Result { get; set; }

        public int StudentId { get; set; }

        public DateTime AbsenceDate { get; set; }
    }
}
