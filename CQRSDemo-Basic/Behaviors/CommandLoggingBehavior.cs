namespace CQRSDemo.Behaviors
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using CQRSDemo.Commands;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class CommandLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : BaseCommand
        where TResponse : CommandResult
    {
        private readonly ILogger<CommandLoggingBehavior<TRequest, TResponse>> _logger;

        public CommandLoggingBehavior(ILogger<CommandLoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            using (_logger.BeginScope(new Dictionary<string, object>{
                ["CommandId"] = request.CommandId,
                ["CommandName"] = typeof(TRequest).Name
            }))
	        {
                _logger.LogInformation("Handling command {@request}", request);
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    var response = await next();
                    _logger.LogDebug("Response was {@response}. Elapsed time: {ElapsedTime}", response, stopwatch.Elapsed);
                    return response;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An exception occurred trying to handle a command. Elapsed time: {ElapsedTime}", stopwatch.Elapsed);
                    return (TResponse)new CommandResult { Success = false };
                }
            }
        }
    }
}
