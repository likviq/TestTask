using TestTask.Views;

namespace TestTask.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionInfo>> GetQuestions(int IdTest);
    }
}
