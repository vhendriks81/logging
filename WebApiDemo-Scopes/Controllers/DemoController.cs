using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private HttpClient _httpClient;
        private readonly ILogger<DemoController> _logger;
        private readonly IDemoService _demoService;

        public DemoController(HttpClient httpClient, ILogger<DemoController> logger, IDemoService demoService)
        {
            _httpClient = httpClient;
            _logger = logger;
            _demoService = demoService;
        }


        [HttpPost()]
        public string DoSomething(string name)
        {
            using (_logger.BeginScope(new Dictionary<string, object>{
                ["Name"] = name,
            }))
            {
                return _demoService.DoSomething(name);
            }
        }
    }
}
