using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private HttpClient _httpClient;
        private readonly ILogger<DemoController> _logger;

        public DemoController(HttpClient httpClient, ILogger<DemoController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        [HttpPost()]
        public string DoSomething(string name)
        {
            _logger.LogInformation("Doing something for {Name}", name);
            return $"Hello {name}. It's currently {DateTime.UtcNow}";
        }
    }
}
