namespace Delfos.Aplication.Service.Response
{
    public class ErrorResponse(string? message, string? code, string? requestId)
    {
        public string Message { get; set; } = message;
        public string? Code { get; set; } = code;
        public string? RequestId { get; set; } = requestId;
    }
}
