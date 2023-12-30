
using FluentValidation;
using MediatR;
using System.IO.Pipes;

namespace Application.Behaviours.User
{
    public class UserValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public UserValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var ValidationResult = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
                var Failures = ValidationResult.SelectMany(r => r.Errors).Where(x => x != null).ToList();
                if (Failures.Count !=0)
                {
                    throw new ValidationException(Failures);
                }
            }

            return await next();  
        }
    }
}
