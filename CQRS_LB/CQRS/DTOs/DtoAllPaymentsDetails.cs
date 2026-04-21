namespace CQRS_LB.CQRS.DTOs
{
    public class DtoAllPaymentsDetails
    {
        public int PaymentId { get; set; }

        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
