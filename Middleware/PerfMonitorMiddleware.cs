using System.Diagnostics;

namespace MiddlewareDemo.Middleware
{
    public class PerfMonitorMiddleware : IMiddleware
    {
        private readonly ILogger<PerfMonitorMiddleware> _logger;
        private Stopwatch? _timer;

        public PerfMonitorMiddleware(ILogger<PerfMonitorMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _timer = new Stopwatch();

            _timer.Start();

            await next(context);

            _timer.Stop();

            var timeTaken = _timer.ElapsedMilliseconds;

            _logger.LogInformation($"Request {context.Request.Path} took {timeTaken}ms");
        }
    }
}