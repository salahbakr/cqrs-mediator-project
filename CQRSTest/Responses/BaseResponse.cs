namespace CQRSTest.Responses;

public class BaseResponse<T> where T : class
{
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public bool IsSuccess { get; set; }
}