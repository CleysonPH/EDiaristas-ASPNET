namespace EDiaristas.Core.Exceptions;

public static class DateTimeExtensions
{
    public static int GetIdade(this DateTime dateTime)
    {
        var idade = DateTime.Now.Year - dateTime.Year;
        if (DateTime.Now.Month < dateTime.Month || (DateTime.Now.Month == dateTime.Month && DateTime.Now.Day < dateTime.Day))
        {
            idade--;
        }
        return idade;
    }

    public static int GetIdade(this DateTime? dateTime)
    {
        var newDateTime = dateTime ?? DateTime.Now;
        var idade = DateTime.Now.Year - newDateTime.Year;
        if (DateTime.Now.Month < newDateTime.Month || (DateTime.Now.Month == newDateTime.Month && DateTime.Now.Day < newDateTime.Day))
        {
            idade--;
        }
        return idade;
    }
}