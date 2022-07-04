namespace EDiaristas.Admin.Common.Dtos;

public class Alert
{
    public string Message { get; set; } = string.Empty;
    public string CssClass { get; set; } = string.Empty;

    public static Alert Success(string message)
    {
        return new Alert
        {
            Message = message,
            CssClass = "alert-success"
        };
    }

    public static Alert Error(string message)
    {
        return new Alert
        {
            Message = message,
            CssClass = "alert-danger"
        };
    }
}