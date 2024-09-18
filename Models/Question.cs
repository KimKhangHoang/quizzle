namespace Quizzle.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; } = "";
        public string OptionA { get; set; } = "";
        public string OptionB { get; set; } = "";
        public string OptionC { get; set; } = "";
        public string OptionD { get; set; } = "";
        public string Answer { get; set; } = "";
    }
}