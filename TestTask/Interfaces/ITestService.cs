using TestTask.Domain.Models;
using TestTask.Views;

namespace TestTask.Interfaces
{
    public interface ITestService
    {
        Task<Test> GetTest(int idTest);
        Task<List<TestInfo>> GetTests(int idUser);
        Task<List<User>> GetAll();
    }
}
