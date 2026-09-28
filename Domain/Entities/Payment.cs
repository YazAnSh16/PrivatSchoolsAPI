namespace PrivatSchoolsAPI.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public int Amount { get; set; }

        public int TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
