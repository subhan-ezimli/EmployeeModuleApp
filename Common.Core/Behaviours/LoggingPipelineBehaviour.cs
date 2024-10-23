using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Common.Core.Behaviours
{
    public class LoggingPipelineBehaviour<TRequest, TResponse>(ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
       where TRequest : notnull, IRequest<TResponse>
       where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Handling process started for {request}");
            var metric = new Stopwatch();
            metric.Start();
            var response = await next();
            metric.Stop();
            var metricTime = metric.Elapsed;
            if (metricTime.Seconds > 5)
                logger.LogWarning("Handling process took to much time. Maybe it needs to be refactored");

            logger.LogInformation($"Handling process done for {request} and you have response {response}");
            return response;
        }
    }
}
