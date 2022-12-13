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
    public class HomeController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly IFillDatabaseService _fillDatabaseService;

        public HomeController(ITestService testService, IQuestionService questionService, IFillDatabaseService fillDatabaseService)
        {
            _testService = testService;
            _questionService = questionService;
            _fillDatabaseService = fillDatabaseService;
        }

        [Authorize]
        [Route("/fill/database")]
        public async Task FillDatabase()
        {
            await _fillDatabaseService.FillDatabase();
        }

        [Authorize]
        [Route("/getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"{User.Identity.Name}");
        }

        [Authorize]
        [Route("/tests")]
        public async Task<List<TestInfo>> GetTestsAsync()
        {
            var userId = int.Parse(User.Identity.Name);
            return await _testService.GetTests(userId);
        }

        [AllowAnonymous]
        [Route("/all/tests")]
        public async Task<List<User>> Index()
        {
            var tests = await _testService.GetAll();
            return tests;
        }

        [AllowAnonymous]
        [Route("/question/{IdTest}")]
        public async Task<List<QuestionInfo>> GetQuestions(int IdTest)
        {
            var questions = await _questionService.GetQuestion(IdTest);
            return questions;
        }
    }
}