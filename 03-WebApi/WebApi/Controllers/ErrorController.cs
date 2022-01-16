using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

// [ApiExplorerSettings(IgnoreApi = true)]
[Route("[controller]")]
[ApiController]
public class ErrorController : Controller
{
    [HttpGet("Throw")]
    public IActionResult Throw() =>
        throw new Exception("Sample exception.");

    [HttpGet("Throw2")]
    public IActionResult Throw2() =>
        throw new UserException();
}

class UserException : Exception
{
    public UserException() : base("user get wrong")
    {
    }
}
