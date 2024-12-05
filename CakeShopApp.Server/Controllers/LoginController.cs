using CakeShopApp.Server.Contexts;
using CakeShopApp.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace CakeShopApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class CheckLoginController : ControllerBase
    {

        //private static readonly string UserNameArr = "Priyanka";
        //private static readonly string PassArr = "priya";

        private readonly ILogger<CheckLoginController> _logger;
        private readonly LoginContext _context;

        public CheckLoginController(ILogger<CheckLoginController> logger, LoginContext context)
        {
            _logger = logger;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost(Name = "checklogin")]
        public async Task<IActionResult> PostLogin([FromBody] LoginModel login)
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

        
       

    }
}
