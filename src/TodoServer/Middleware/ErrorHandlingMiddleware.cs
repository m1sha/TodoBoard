using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TodoServer.Middleware
{
  public class ErrorHandlingMiddleware
  {
    #region fields

    private readonly RequestDelegate next;

    #endregion

    #region constructors

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
      this.next = next;
    }

    #endregion

    #region methods

    public async Task Invoke(HttpContext context /* other dependencies */)
    {
      try
      {
        await next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }

    #endregion

    #region helpers

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
      var code = HttpStatusCode.InternalServerError; // 500 if unexpected


      var result = JsonConvert.SerializeObject(new { error = ex.Message });
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)code;
      return context.Response.WriteAsync(result);
    }

    #endregion
  }
}
