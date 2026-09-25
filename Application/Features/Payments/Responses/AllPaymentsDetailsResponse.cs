namespace Application.Features.Payments.Responses
{
    public class AllPaymentsDetailsResponse
    {
        public Guid PaymentId { get; set; }

        public Guid StudentId { get; set; }

        public string StudentName { get; set; }
        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
