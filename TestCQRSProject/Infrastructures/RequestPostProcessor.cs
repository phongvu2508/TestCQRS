using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace TestCQRSProject.Infrastructures
{
    public class RequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public RequestPostProcessor(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //TODO: Cover all the validation for the request here

            return next();
        }

        public Task Process(TRequest request, TResponse response)
        {
            var name = typeof(TRequest).Name;

            // TODO: Add User Details

            _logger.LogInformation("End API Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}
