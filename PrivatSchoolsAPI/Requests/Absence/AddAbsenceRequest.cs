namespace CQRS_LB.CQRS.DTOs
{
    public class AddAbsenceRequest
    {


        public bool Result { get; set; }

        public Guid StudentId { get; set; }

        public DateTime AbsenceDate { get; set; }
    }
}
