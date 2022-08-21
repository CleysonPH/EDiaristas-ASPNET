namespace EDiaristas.Api.Common.Dtos;

public class MessageResponse
{
    public string Message { get; set; } = string.Empty;

    public MessageResponse()
    { }

    public MessageResponse(string message)
    {
        Message = message;
    }
}