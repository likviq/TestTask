using TestTask.Interfaces;
using TestTask.Domain.Models;
using TestTask.Domain;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Services
{
    public class FillDatabaseService : IFillDatabaseService
    {
        private readonly testsDBContext _context;

        public FillDatabaseService(testsDBContext context)
        {
            _context = context;
        }

        public async Task FillDatabase()
        {
            var test1 = new Test { Description = "First description", Title = "Test 1", CreatorId = 0 };
            var test2 = new Test { Description = "Second description", Title = "Test 2", CreatorId = 1 };
            var test3 = new Test { Description = "Third description", Title = "Test 3", CreatorId = 2 };
            
            await _context.AddRangeAsync(test1, test2, test3);

            var questionTest11 = new Question { Content = "What is 2+2?", Mark = 2, Tests = test1 };
            var questionTest12 = new Question { Content = "What is 2+3?", Mark = 3, Tests = test1 };
            var questionTest13 = new Question { Content = "What is 2+4?", Mark = 4, Tests = test1 };

            await _context.AddRangeAsync(questionTest11, questionTest12, questionTest13);

            var answerTest1Quetion11 = new Answer { Content = "3", IsCorrect = false, Question = questionTest11 };
            var answerTest1Quetion12 = new Answer { Content = "4", IsCorrect = true, Question = questionTest11 };

            var answerTest1Quetion21 = new Answer { Content = "4", IsCorrect = false, Question = questionTest12 };
            var answerTest1Quetion22 = new Answer { Content = "5", IsCorrect = true, Question = questionTest12 };

            var answerTest1Quetion31 = new Answer { Content = "6", IsCorrect = true, Question = questionTest13 };
            var answerTest1Quetion32 = new Answer { Content = "5", IsCorrect = false, Question = questionTest13 };

            await _context.AddRangeAsync(answerTest1Quetion11, answerTest1Quetion12, answerTest1Quetion21, answerTest1Quetion22, answerTest1Quetion31, answerTest1Quetion32);

            var questionTest21 = new Question { Content = "What is 3+2?", Mark = 2, Tests = test2 };
            var questionTest22 = new Question { Content = "What is 3+3?", Mark = 3, Tests = test2 };
            var questionTest23 = new Question { Content = "What is 3+4?", Mark = 4, Tests = test2 };

            await _context.AddRangeAsync(questionTest21, questionTest22, questionTest23);

            var answerTest2Quetion11 = new Answer { Content = "4", IsCorrect = false, Question = questionTest21 };
            var answerTest2Quetion12 = new Answer { Content = "5", IsCorrect = true, Question = questionTest21 };

            var answerTest2Quetion21 = new Answer { Content = "5", IsCorrect = false, Question = questionTest22 };
            var answerTest2Quetion22 = new Answer { Content = "6", IsCorrect = true, Question = questionTest22 };

            var answerTest2Quetion31 = new Answer { Content = "14/2", IsCorrect = true, Question = questionTest23 };
            var answerTest2Quetion32 = new Answer { Content = "7", IsCorrect = true, Question = questionTest23 };

            await _context.AddRangeAsync(answerTest2Quetion11, answerTest2Quetion12, answerTest2Quetion21, answerTest2Quetion22, answerTest2Quetion31, answerTest2Quetion32);

            var questionTest31 = new Question { Content = "What is 4+2?", Mark = 2, Tests = test3 };
            var questionTest32 = new Question { Content = "What is 4+3?", Mark = 3, Tests = test3 };
            var questionTest33 = new Question { Content = "What is 4+4?", Mark = 4, Tests = test3 };

            await _context.AddRangeAsync(questionTest31, questionTest32, questionTest33);

            var answerTest3Quetion11 = new Answer { Content = "5", IsCorrect = false, Question = questionTest31 };
            var answerTest3Quetion12 = new Answer { Content = "6", IsCorrect = true, Question = questionTest31 };

            var answerTest3Quetion21 = new Answer { Content = "6", IsCorrect = false, Question = questionTest32 };
            var answerTest3Quetion22 = new Answer { Content = "7", IsCorrect = true, Question = questionTest32 };

            var answerTest3Quetion31 = new Answer { Content = "8", IsCorrect = true, Question = questionTest33 };
            var answerTest3Quetion32 = new Answer { Content = "70", IsCorrect = false, Question = questionTest33 };

            await _context.AddRangeAsync(answerTest3Quetion11, answerTest3Quetion12, answerTest3Quetion21, answerTest3Quetion22, answerTest3Quetion31, answerTest3Quetion32);

            var user1 = await _context.Users.FirstOrDefaultAsync(x => x.IdUser == 1);
            var user2 = await _context.Users.FirstOrDefaultAsync(x => x.IdUser == 2);

            user1.Tests.Add(test1);
            user1.Tests.Add(test2);

            user2.Tests.Add(test2);
            user2.Tests.Add(test3);
            user2.Tests.Add(test1);

            await _context.SaveChangesAsync();
        }
    }
}