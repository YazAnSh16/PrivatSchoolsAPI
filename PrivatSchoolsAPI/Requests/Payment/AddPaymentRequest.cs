namespace PrivatSchoolsAPI.API.Requests.Payment
{
    public class AddPaymentRequest
    {
        public int StudentId { get; set; }
        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
