using JWT_test.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JWT_test.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is UserFriendlyException)
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.Message,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            else //các ngoại lệ khác
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
