using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                LogException(ex, LogLevel.Error, request);
                throw;
            }
        }

        private void LogException(Exception ex, LogLevel level, TRequest request)
        {
            _logger.Log(
                level,
                ex,
                "SettlementBookingSystem: {ExceptionType} for Request {Name} {@Request}",
                ex.GetType().Name,
                typeof(TRequest).Name,
                request);
        }
    }
}
