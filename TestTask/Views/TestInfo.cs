namespace TestTask.Views
{
    public class TestInfo
    {
        public TestInfo(int idTest, string description, string title)
        {
            IdTest = idTest;
            Description = description;
            Title = title;
        }
        public int IdTest { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
