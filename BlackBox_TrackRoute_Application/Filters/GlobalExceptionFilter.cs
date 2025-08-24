using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlackBox_TrackRoute_Application.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context == null || context.Exception == null)
                return; 

            _logger.LogError(context.Exception, "Unhandled exception occurred.");

            context.Result = new ViewResult
            {
                ViewName = "/Views/Shared/Error.cshtml" 
            };

            context.ExceptionHandled = true; 
        }

    }
}
