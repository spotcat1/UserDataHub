

using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Application.Behaviours.User
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Request

            _logger.LogInformation($"handling {typeof(TRequest).Name}");
            Type MyType = request.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(MyType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                object PropValue = prop.GetValue(request, null);
                _logger.LogInformation("{Property} {@Value}",prop.Name, PropValue); 
            }

            var Response = await next();

            //Response

            _logger.LogInformation($"Handled {typeof(TResponse).Name}");
            return Response;
        }
    }
}
