namespace RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

public class NoContentException : ApplicationException
{
    public NoContentException(string message) : base(message, 204) { }
}
