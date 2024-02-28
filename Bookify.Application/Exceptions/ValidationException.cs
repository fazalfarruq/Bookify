namespace Bookify.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(IReadOnlyCollection<ValidationError> errors)
    {
        Errors = errors;
    }

    public IReadOnlyCollection<ValidationError> Errors { get; }
}