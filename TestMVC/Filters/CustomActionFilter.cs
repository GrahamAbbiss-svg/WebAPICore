using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVC.Filters
{
    public class CustomActionFilter : IActionFilter
    {
        private ILogger _logger;

        public CustomActionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CustomActionFilter>();

        }
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Executed");
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Executing");
        }
    }
}
