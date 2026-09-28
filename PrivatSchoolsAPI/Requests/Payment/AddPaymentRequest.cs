namespace PrivatSchoolsAPI.API.Requests.Payment
{
    public class AddPaymentRequest
    {
        public Guid StudentId { get; set; }
        public int Amount { get; set; }

        public int TotalAmount { get; set; }
    }
}
