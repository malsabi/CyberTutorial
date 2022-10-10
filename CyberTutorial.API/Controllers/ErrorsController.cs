using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CyberTutorial.API.Controllers
{
    [AllowAnonymous]
    public class ErrorsController : ApiController
    {
        [HttpGet("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}