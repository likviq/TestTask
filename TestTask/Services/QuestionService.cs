using Microsoft.EntityFrameworkCore;
using TestTask.Domain;
using TestTask.Domain.Models;
using TestTask.Interfaces;
using TestTask.Views;

namespace TestTask.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly testsDBContext _context;

        public QuestionService(testsDBContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionInfo>> GetQuestion(int IdTest)
        {
            var questions = await _context.Questions.Include(x => x.Answers).Where(x => x.TestId == IdTest).ToListAsync();
            List<QuestionInfo> questionsInfo = new List<QuestionInfo>();
            foreach (Question q in questions)
            {
                var question = new QuestionInfo();
                question.IdQuestion = q.IdQuestion;
                question.Content = q.Content;
                question.Mark = q.Mark;
                question.Answers = q.Answers.Select(x => x.Content).ToList();
                questionsInfo.Add(question);
            }
            return questionsInfo;
        }
    }
}
