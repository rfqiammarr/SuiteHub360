using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;

public static class ListExtensions
{
    public static ListResponse<T> ToListResponse<T>(this List<T> source)
    {
        return new ListResponse<T> { Items = source };
    }
}
