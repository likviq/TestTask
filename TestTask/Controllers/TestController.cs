using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTask.Interfaces;
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
        public async Task<IActionResult> GetTestsAsync()
        {
            var tokenIdUser = int.Parse(User.Identity.Name);

            var tests = await _testService.GetTests(tokenIdUser);

            if (tests == null)
            {
                return NotFound(tokenIdUser);
            }

            return Ok(tests);
        }

        [Authorize]
        [Route("/question/{IdTest}")]
        public async Task<IActionResult> GetQuestions(int IdTest)
        {
            var questions = await _questionService.GetQuestions(IdTest);
            
            if (questions == null)
            {
                return NotFound(IdTest);
            }
            
            return Ok(questions);
        }

        [Authorize]
        [HttpPost("/mark/{IdTest}")]
        public async Task<IActionResult> GetMark(int IdTest, [FromBody] List<string> answers)
        {
            var mark = await _testService.GetMark(IdTest, answers);

            if (mark == null)
            {
                return NotFound(IdTest);
            }

            return Ok(mark);
        }
    }
}