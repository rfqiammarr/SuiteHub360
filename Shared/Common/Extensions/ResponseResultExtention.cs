using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;


public static class ResponseResultExtension
{
    public static ResponseResult<T> ToResponseResult<T>(this T source) where T : Response
    {
        return new ResponseResult<T> { Result = source };
    }
}
