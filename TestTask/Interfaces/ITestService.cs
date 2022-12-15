using TestTask.Views;

namespace TestTask.Interfaces
{
    public interface ITestService
    {
        Task<List<TestInfo>> GetTests(int idUser);
        Task<int?> GetMark<T>(int IdTest, List<T> answers);
    }
}
