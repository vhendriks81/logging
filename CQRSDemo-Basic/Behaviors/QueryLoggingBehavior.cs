namespace CQRSDemo.Behaviors
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using CQRSDemo.Commands;
    using CQRSDemo.Queries;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class QueryLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : BaseQuery
    {
        private readonly ILogger<QueryLoggingBehavior<TRequest, TResponse>> _logger;

        public QueryLoggingBehavior(ILogger<QueryLoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            using (_logger.BeginScope(new Dictionary<string, object>{
                ["QueryName"] = typeof(TRequest).Name
            }))
	        {
                _logger.LogInformation("Handling query {@request}", request);
                var response = await next();
                _logger.LogDebug("Query completed. Response was {@response}", response);
                
                return response;
            }
        }
    }
}