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


        [HttpGet("First")]
        public async Task<string> GetOne(string name)
        {
            var twoResponse = await _httpClient.GetStringAsync("http://localhost:5000/Demo/Second");
            return twoResponse;
        }

        [HttpGet("Second")]
        public string GetTwo()
        {
            _logger.LogInformation("From Second");
            _logger.LogInformation("Input headers: {@RequestHeaders}", Request.Headers);
             return "Message from Second api call";
        }
    }
}
