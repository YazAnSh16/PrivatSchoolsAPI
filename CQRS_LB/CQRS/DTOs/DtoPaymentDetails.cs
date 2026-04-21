namespace CQRS_LB.CQRS.DTOs
{
    public class DtoPaymentDetails
    {
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
