namespace Application.Features.Payments.Responses
{
    public class PaymentDetailsResponse
    {
        public Guid PaymentId { get; set; }
        public Guid StudentId { get; set; }
        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
