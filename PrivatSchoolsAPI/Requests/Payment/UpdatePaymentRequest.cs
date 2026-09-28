namespace PrivatSchoolsAPI.API.Requests.Payment
{
    public class UpdatePaymentRequest
    {

        public int Amount { get; set; }

        public int TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
