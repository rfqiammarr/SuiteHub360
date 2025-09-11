namespace RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

public class ConflictException : ApplicationException
{
    public ConflictException(string message) : base(message, 409) { }
}
