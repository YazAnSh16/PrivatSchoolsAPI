namespace PrivatSchoolsAPI.API.Requests.Payment
{
    public class UpdatePaymentRequest
    {

        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
