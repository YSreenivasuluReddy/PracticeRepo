using System.Security.Authentication;

namespace CustomMiddlewareDemo.Middleware
{
    public class GlobalExceptionMiddleware
    {
        //here requestdelegate is used to holds the next middleware.
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        //HttpContext - is used to provides the request and response details.
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //here it finds the errors.
                _logger.LogError(ex, "Unhandled exception occurred");

                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.Clear();
                //context.Response.StatusCode =
                //    StatusCodes.Status500InternalServerError;

                int statusCode;
                string message;
                switch (ex)
                {
                    case ArgumentException:
                        statusCode = StatusCodes.Status400BadRequest;
                        message = "Invalid request parameters";
                        break;
                   
                    case AuthenticationException:
                        statusCode = StatusCodes.Status401Unauthorized;
                        message = "Authentication failed";
                        break;

                    case UnauthorizedAccessException:
                        statusCode = StatusCodes.Status403Forbidden;
                        message = "Access Denied";
                        break;

                    case KeyNotFoundException:
                        statusCode = StatusCodes.Status404NotFound;
                        message = "Record Not Found";
                        break;

                    case InvalidOperationException:
                        statusCode = StatusCodes.Status409Conflict;
                        message = "Operation conflict";
                        break;

                    default:
                        statusCode = StatusCodes.Status500InternalServerError;
                        message = "Internal server error";
                        break;
                }

                await context.Response.WriteAsJsonAsync(new
                {
                    StatusCode = statusCode,
                    Message = message,
                    TraceId = context.TraceIdentifier
                });
            }
        }
    }
}
