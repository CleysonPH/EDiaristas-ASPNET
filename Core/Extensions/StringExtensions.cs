namespace EDiaristas.Core.Extensions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string str)
    {
        return string.Concat(
            str.Select((x, i) => i > 0 &&
            char.IsUpper(x) ? "_" + x.ToString() : x.ToString())
        ).ToLower();
    }

    public static bool IsValidCpf(this string str)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        int soma;
        int resto;
        string digito;
        string tempCpf;

        tempCpf = str.Trim();
        tempCpf = tempCpf.Replace(".", "").Replace("-", "");

        if (tempCpf.Length != 11)
            return false;

        switch (tempCpf)
        {
            case "11111111111":
                return false;
            case "22222222222":
                return false;
            case "33333333333":
                return false;
            case "44444444444":
                return false;
            case "55555555555":
                return false;
            case "66666666666":
                return false;
            case "77777777777":
                return false;
            case "88888888888":
                return false;
            case "99999999999":
                return false;
            default:
                break;
        }

        soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();
        return tempCpf.EndsWith(digito);
    }
}