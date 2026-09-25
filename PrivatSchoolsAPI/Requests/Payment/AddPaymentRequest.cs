namespace PrivatSchoolsAPI.API.Requests.Payment
{
    public class AddPaymentRequest
    {
        public Guid StudentId { get; set; }
        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
