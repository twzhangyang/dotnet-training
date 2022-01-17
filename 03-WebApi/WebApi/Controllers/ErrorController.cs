using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

// [ApiExplorerSettings(IgnoreApi = true)]
[Route("[controller]")]
[ApiController]
public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Throw")]
    public IActionResult Throw() =>
        throw new Exception("Sample exception.");

    [HttpGet("Throw2")]
    public IActionResult Throw2() =>
        throw new UserException();

    [HttpGet("Throw3")]
    public IActionResult Throw3()
    {
        try
        {
            throw new UserException();
        }
        catch (Exception e)
        {
            _logger.LogCritical(exception:e, "throw 3" );
        }

        return Ok();
    }
}

class UserException : Exception
{
    public UserException() : base("user get wrong")
    {
    }
}
