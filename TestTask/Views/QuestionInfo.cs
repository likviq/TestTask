namespace TestTask.Views
{
    public class QuestionInfo
    {
        public int IdQuestion { get; set; }
        public string? Content { get; set; }
        public int Mark { get; set; }
        public List<string> Answers { get; set; }
    }
}
