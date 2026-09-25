namespace PrivatSchoolsAPI.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
