﻿namespace RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string message) : base(message, 404) { }
}
