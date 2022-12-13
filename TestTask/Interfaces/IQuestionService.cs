using TestTask.Domain.Models;
using TestTask.Views;

namespace TestTask.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionInfo>> GetQuestion(int IdTest);
    }
}
