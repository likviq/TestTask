using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTask.Interfaces;

namespace TestTask.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly IFillDatabaseService _fillDatabaseService;
        public DatabaseController(IFillDatabaseService fillDatabaseService)
        {
            _fillDatabaseService = fillDatabaseService;
        }

        [Authorize]
        [Route("/fill/database")]
        public async Task FillDatabase()
        {
            await _fillDatabaseService.FillDatabase();
        }
    }
}
