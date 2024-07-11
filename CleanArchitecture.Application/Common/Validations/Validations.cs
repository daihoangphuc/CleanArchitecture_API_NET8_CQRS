using FluentValidation;
using MediatR;


namespace CleanArchitecture.Application.Common.Validations
{
    public class Validations<TRequest, TRespones> : IPipelineBehavior<TRequest, TRespones> where TRequest : notnull
    {
        public readonly IEnumerable<IValidator<TRequest>> _validators;

        public Validations(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TRespones> Handle(TRequest request, RequestHandlerDelegate<TRespones> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll( _validators.Select(v => v.ValidateAsync(context)));
                var failures = validationResults.Where(r => r.Errors.Any()).SelectMany(r => r.Errors).ToList();
                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
