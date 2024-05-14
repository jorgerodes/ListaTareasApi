using ListaTareasApi.Application.Abstractions.Behaviours;


namespace ListaTareasApi.Application.Abstractions.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }

    public IEnumerable<ValidationError> Errors { get; set; }
}