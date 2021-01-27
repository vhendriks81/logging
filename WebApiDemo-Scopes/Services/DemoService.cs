namespace WebApiDemo.Services
{
    using System;
    using Microsoft.Extensions.Logging;

    public class DemoService : IDemoService
    {
        private readonly ILogger<DemoService> _logger;

        public DemoService(ILogger<DemoService> logger)
        {
            _logger = logger;
        }

        public string DoSomething(string name)
        {
            _logger.LogInformation("Doing something..");
            return $"Hello {name}. It's currently {DateTime.UtcNow}";
        }
    }
}
