using FluentValidation;
using LiteBus.Commands.Abstractions;

namespace NexCore.Application.Common.Behaviors;

public sealed class ValidationBehavior<TCommand> : ICommandPreHandler<TCommand>
    where TCommand : ICommand
{
    private readonly IEnumerable<IValidator<TCommand>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TCommand>> validators)
    {
        _validators = validators;
    }

    public async Task PreHandleAsync(TCommand message, CancellationToken cancellationToken = default)
    {
        if (!_validators.Any()) return;

        var context = new ValidationContext<TCommand>(message);

        var results = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = results
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToList();

        if (failures.Count > 0)
            throw new ValidationException(failures);
    }
}