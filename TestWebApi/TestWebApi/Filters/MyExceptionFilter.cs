using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace TestWebApi.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        public MyExceptionFilter(IWebHostEnvironment hostEnv, ILogger<MyExceptionFilter> logger)
        {
            _hostingEnvironment = hostEnv;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError("Exception Occured {Exception} : {RequestTime}", context.Exception ,DateTime.Now);
            
            var result = new ObjectResult("Errore custom per Testare il filtro");
            result.StatusCode = 400; 
            context.Result = result;
        }
    }
}
