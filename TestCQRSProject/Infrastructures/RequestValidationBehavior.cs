using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace TestCQRSProject.Infrastructure
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public RequestValidationBehavior()
        {
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //TODO: Cover all the validation for the request here

            return next();
        }
    }
}
