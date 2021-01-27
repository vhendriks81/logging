namespace WebApiDemo.Middleware
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Serilog.Context;

    public class LogUserNameMiddleware
    {
        private readonly RequestDelegate next;

        public LogUserNameMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            LogContext.PushProperty("UserName", context.User?.Identity?.Name ?? "Anonymous");

            return next(context);
        }
    }
}
