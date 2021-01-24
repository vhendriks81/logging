namespace CQRSDemo.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Commands;
    using Microsoft.Extensions.Logging;

    public class AccountCommandHandler
        : IHandleCommand<CreateAccount>
    {
        private readonly ILogger<AccountCommandHandler> _logger;

        public AccountCommandHandler(ILogger<AccountCommandHandler> logger)
        {
            _logger = logger;
        }

        public Task<CommandResult> Handle(CreateAccount request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Checking create account request");
            if (request.Name.Contains("exception"))
            {
                throw new System.Exception("Testing an exception");
            }

            _logger.LogInformation("Creating account");
            return Task.FromResult(new CommandResult { Success = true });
        }
    }
}
