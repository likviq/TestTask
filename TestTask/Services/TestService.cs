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


        public async Task<Test> GetTest(int idTest)
        {
            var test = await _context.Tests
                .FirstOrDefaultAsync(x => x.IdTest == idTest);
            
            return test;
        }

        public async Task<List<TestInfo>> GetTests(int idUser)
        {
            var user = await _context.Users.Include(x => x.Tests).FirstOrDefaultAsync(x => x.IdUser == idUser);

            List<TestInfo> tests = new List<TestInfo>();
            foreach(Test t in user.Tests)
            {
                var test = new TestInfo();
                test.IdTest = t.IdTest;
                test.Title = t.Title;
                test.Description = t.Description;
                tests.Add(test);
            }

            return tests;
        }

        public async Task<List<User>> GetAll()
        {
            var tests = await _context.Users.Include(x => x.Tests)
                .ToListAsync();

            return tests;
        }
    }
}
