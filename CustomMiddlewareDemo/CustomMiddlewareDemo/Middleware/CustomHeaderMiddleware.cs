namespace CustomMiddlewareDemo.Middleware
{
    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers["X-Application-Name"] =
                    "CustomMiddlewareDemo";

                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
