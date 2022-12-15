using Microsoft.EntityFrameworkCore;
using TestTask.Domain;
using TestTask.Domain.Models;
using TestTask.Interfaces;
using TestTask.Views;

namespace TestTask.Services
{
    public class TestService : ITestService
    {
        private readonly testsDBContext _context;

        public TestService(testsDBContext context)
        {
            _context = context;
        }

        public async Task<List<TestInfo>> GetTests(int idUser)
        {
            var user = await _context.Users.Include(x => x.Tests).FirstOrDefaultAsync(x => x.IdUser == idUser);

            List<TestInfo> tests = new List<TestInfo>();
            foreach(Test t in user.Tests)
            {
                var test = new TestInfo(t.IdTest, t.Description, t.Title);
                tests.Add(test);
            }

            return tests;
        }

        public async Task<int?> GetMark<T>(int IdTest, List<T> answers)
        {
            var test = await _context.Tests.FirstOrDefaultAsync(x => x.IdTest == IdTest);
            
            if (test == null)
            {
                return null;
            }

            var questions = await _context.Questions
                .Where(x => x.TestId == test.IdTest)
                .Include(x => x.Answers)
                .ToListAsync();

            var mark = 0;
            for (int i = 0; i<questions.Count; i++)
            {
                foreach (var answer in questions[i].Answers)
                {
                    if (answer.IsCorrect && answer.Content.Equals(answers[i]))
                    {
                        mark += questions[i].Mark;
                    }
                }
            }

            return mark;
        }
    }
}
