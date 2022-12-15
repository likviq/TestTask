using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        [Route("/userId")]
        public async Task<IActionResult> GetUserId()
        {
            var IdUser = User.Identity.Name;

            if (IdUser == null)
            {
                return NotFound();
            }

            return Ok(int.Parse(IdUser));
        }
    }
}
