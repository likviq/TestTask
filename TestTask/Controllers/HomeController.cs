using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTask.Models;

namespace TestTask.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        [Authorize]
        [Route("/getlogin")]
        public IActionResult GetLogin()
        {
            return Ok("Everything is working");
        }
    }
}