using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace TestWebApi.Filters
{
    public class LogResultFilter : IResultFilter
    {
        private readonly ILogger _logger;
        public LogResultFilter(ILogger<LogResultFilter> logger) {
            _logger = logger;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            var result = context.HttpContext.Response.StatusCode;
            _logger.LogInformation("Risutlato Prodotto : {Resp} , {Time}", result , DateTime.Now);
            
        }
        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("Risultato in produzione per : {Req}/{path} , {Time}", context.HttpContext.Request.Method, context.HttpContext.Request.Path , DateTime.Now);
        }
    }
}
