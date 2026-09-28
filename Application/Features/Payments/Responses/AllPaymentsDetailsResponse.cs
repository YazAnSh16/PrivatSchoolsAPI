namespace Application.Features.Payments.Responses
{
    public class AllPaymentsDetailsResponse
    {
        public Guid PaymentId { get; set; }

        public Guid StudentId { get; set; }

        public string StudentName { get; set; }
        public int Amount { get; set; }

        public int TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
