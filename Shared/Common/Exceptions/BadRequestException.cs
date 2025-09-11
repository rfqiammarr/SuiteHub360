namespace RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

public class BadRequestException(string message) : ApplicationException(message, 400)
{
}
