using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Controllers;

namespace WebApi.Error;

public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
{
    private readonly ILogger<HttpResponseExceptionFilter> _logger;

    public HttpResponseExceptionFilter(ILogger<HttpResponseExceptionFilter> logger)
    {
        _logger = logger;
    }
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is UserException userException)
        {
            context.Result = new JsonResult(new ErrorModel(new List<ErrorModel.ErrorItem>(){new(userException.Message, "UserCodeIsWrong")}))
            {
                StatusCode =  (int)HttpStatusCode.BadRequest,
            };

            context.ExceptionHandled = true;
        }
        else
        {
            // unhandled exceptions
            _logger.LogCritical(context.Exception, "unhandled exception");
        }
    }
}
