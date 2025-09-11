﻿namespace RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

public class ListResponse<T> : Response
{
    public IList<T> Items { get; set; } = new List<T>();
}
