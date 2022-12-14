using TestTask.Views;

namespace TestTask.Interfaces
{
    public interface ITestService
    {
        Task<List<TestInfo>> GetTests(int idUser);
        Task<int> GetMark(int IdTest, List<string> answers);
    }
}
