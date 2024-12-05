using CakeShopApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CakeShopApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CakeController : Controller
    {
        private readonly ILogger<CakeController> _logger;

        public CakeController(ILogger<CakeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCakeList")]

        public async Task<IActionResult> GetCake([FromBody] CakeModel cake)
        {
            // Validate input
            if (string.IsNullOrEmpty(login.userName) || string.IsNullOrEmpty(login.pass))
            {
                _logger.LogWarning("Login attempt with empty username or password.");
                return BadRequest("Username or password cannot be empty.");
            }
            // Compare credentials
            var result = await _context.CheckRequestParametersAsync(login.userName, login.pass);


            return Ok(result);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
