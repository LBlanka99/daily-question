namespace Services.Exceptions;

public class EmailAlreadyInUseException : Exception
{
    public EmailAlreadyInUseException(string? message) : base(message)
    {
    }
}