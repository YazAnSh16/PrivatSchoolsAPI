namespace Application.Features.Payments.Responses
{
    public class PaymentDetailsResponse
    {
        public Guid PaymentId { get; set; }
        public Guid StudentId { get; set; }
        public int Amount { get; set; }
        public int PaidAmount { get; set; }
        public int TotalAmount { get; set; }

        public int RemainingAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
