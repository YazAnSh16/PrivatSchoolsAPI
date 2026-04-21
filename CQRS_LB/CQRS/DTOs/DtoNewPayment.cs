namespace CQRS_LB.CQRS.DTOs
{
    public class DtoNewPayment
    {
        public int StudentId { get; set; }
        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
