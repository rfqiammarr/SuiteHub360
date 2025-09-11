namespace RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

public class ForbiddenException : ApplicationException
{
    public ForbiddenException(string message) : base(message, 403) { }
}
