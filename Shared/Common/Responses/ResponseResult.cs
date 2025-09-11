namespace RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

public class ResponseResult<T> where T : Response
{
    public T? Result { get; set; }
}
