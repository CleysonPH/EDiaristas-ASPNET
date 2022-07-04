namespace EDiaristas.Core.Models;

public enum Icone
{
    TwfCleaning1 = 1,
    TwfCleaning2 = 2,
    TwfCleaning3 = 3,
}

public static class IconeExtensions
{
    public static string ToName(this Icone icone)
    {
        return icone switch
        {
            Icone.TwfCleaning1 => "twf-cleaning-1",
            Icone.TwfCleaning2 => "twf-cleaning-2",
            Icone.TwfCleaning3 => "twf-cleaning-3",
            _ => throw new ArgumentOutOfRangeException(nameof(icone), icone, null)
        };
    }

    public static Icone ToIcone(this string icone)
    {
        return icone switch
        {
            "twf-cleaning-1" => Icone.TwfCleaning1,
            "twf-cleaning-2" => Icone.TwfCleaning2,
            "twf-cleaning-3" => Icone.TwfCleaning3,
            _ => throw new ArgumentOutOfRangeException(nameof(icone), icone, null)
        };
    }

    public static Icone ToIcone(this int icone)
    {
        return icone switch
        {
            1 => Icone.TwfCleaning1,
            2 => Icone.TwfCleaning2,
            3 => Icone.TwfCleaning3,
            _ => throw new ArgumentOutOfRangeException(nameof(icone), icone, null)
        };
    }
}