using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Error;

 public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var logger = app.ApplicationServices.GetRequiredService<ILogger<Program>>();
                    var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (contextFeature != null)
                    {
                        var ex = contextFeature.Error;
                        var isDev = env.IsDevelopment();
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(
                            new ProblemDetails
                            {

                                Type = ex.GetType().Name,
                                Status = (int)HttpStatusCode.InternalServerError,
                                Instance = contextFeature.Path,
                                Title = isDev ? $"{ex.Message}" : "An error occurred.",
                                Detail = isDev ? ex.StackTrace : null
                            }));
                        logger.LogCritical(ex, "Unhandled exception");
                    }
                });
            });
        }
    }
