using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTask.Models;
using TestTask.Interfaces;
using TestTask.Domain.Models;
using TestTask.Views;

namespace TestTask.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;

        public TestController(ITestService testService, IQuestionService questionService)
        {
            _testService = testService;
            _questionService = questionService;
        }

        [Authorize]
        [Route("/tests")]
        public async Task<List<TestInfo>> GetTestsAsync()
        {
            var userId = int.Parse(User.Identity.Name);
            var tests = await _testService.GetTests(userId);
            return tests;
        }

        [Authorize]
        [Route("/question/{IdTest}")]
        public async Task<List<QuestionInfo>> GetQuestions(int IdTest)
        {
            var questions = await _questionService.GetQuestions(IdTest);
            return questions;
        }

        [Authorize]
        [HttpPost("/mark/{IdTest}")]
        public async Task<int> GetMark(int IdTest, [FromBody] List<string> answers)
        {
            var mark = await _testService.GetMark(IdTest, answers);
            return mark;
        }
    }
}