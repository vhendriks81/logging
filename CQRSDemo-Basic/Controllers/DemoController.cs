using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CQRSDemo.Commands;

namespace CQRSDemo.Controllers
{
    using CQRSDemo.Queries;
    using CQRSDemo.Queries.Models;
    using MediatR;

    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        private readonly IMediator _mediator;

        public DemoController(ILogger<DemoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("CreateAccount")]
        public async Task<CommandResult> ExecuteCommandCreateAccount(CreateAccount command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("QueryAccounts")]
        public async Task<IEnumerable<Account>> ExecuteQueryAccounts([FromQuery] QueryAccounts query)
        {
            return await _mediator.Send(query);
        }
    }
}
