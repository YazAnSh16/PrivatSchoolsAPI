namespace PrivatSchoolsAPI.Domain.Entities
{
    public class TestResult
    {
        public Guid Id { get; set; }

        public TestSubject TestSubject { get; set; }

        public required string Result { get; set; }

        public DateTime TestDate { get; set; } = DateTime.Now;

        public Guid StudentId { get; set; }

        public Student Student { get; set; }
    }

    public enum TestSubject
    {
        Mathematics = 1,
        Physics = 2,
        Chemistry = 3,
        Science = 4,
        ArabicLanguage = 5,
        FrenchLanguage = 6,
        EnglishLanguage = 7,
        ReligiousEducation = 8
    }
}
