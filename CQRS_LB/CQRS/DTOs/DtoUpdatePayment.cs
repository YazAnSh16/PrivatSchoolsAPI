namespace CQRS_LB.CQRS.DTOs
{
    public class DtoUpdatePayment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
