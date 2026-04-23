namespace PrivatSchoolsAPI.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public decimal Amount { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
