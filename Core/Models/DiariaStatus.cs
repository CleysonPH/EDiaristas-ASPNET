namespace EDiaristas.Core.Models;

public enum DiariaStatus
{
    SemPagamento = 1,
    Pago = 2,
    Confirmado = 3,
    Concluido = 4,
    Cancelado = 5,
    Avaliado = 6,
    Transferido = 7,
}

public static class DiariaStatusExtensions
{
    public static string ToDiariaStatusName(this DiariaStatus diariaStatus)
    {
        return diariaStatus switch
        {
            DiariaStatus.SemPagamento => "SemPagamento",
            DiariaStatus.Pago => "Pago",
            DiariaStatus.Confirmado => "Confirmado",
            DiariaStatus.Concluido => "Concluido",
            DiariaStatus.Cancelado => "Cancelado",
            DiariaStatus.Avaliado => "Avaliado",
            DiariaStatus.Transferido => "Transferido",
            _ => throw new ArgumentOutOfRangeException(nameof(diariaStatus), diariaStatus, null)
        };
    }

    public static DiariaStatus ToDiariaStatus(this string diariaStatus)
    {
        return diariaStatus switch
        {
            "SemPagamento" => DiariaStatus.SemPagamento,
            "Pago" => DiariaStatus.Pago,
            "Confirmado" => DiariaStatus.Confirmado,
            "Concluido" => DiariaStatus.Concluido,
            "Cancelado" => DiariaStatus.Cancelado,
            "Avaliado" => DiariaStatus.Avaliado,
            "Transferido" => DiariaStatus.Transferido,
            _ => throw new ArgumentOutOfRangeException(nameof(diariaStatus), diariaStatus, null)
        };
    }

    public static DiariaStatus ToDiariaStatus(this int diariaStatus)
    {
        return diariaStatus switch
        {
            1 => DiariaStatus.SemPagamento,
            2 => DiariaStatus.Pago,
            3 => DiariaStatus.Confirmado,
            4 => DiariaStatus.Concluido,
            5 => DiariaStatus.Cancelado,
            6 => DiariaStatus.Avaliado,
            7 => DiariaStatus.Transferido,
            _ => throw new ArgumentOutOfRangeException(nameof(diariaStatus), diariaStatus, null)
        };
    }

    public static int ToDiariaStatusInt(this DiariaStatus diariaStatus)
    {
        return diariaStatus switch
        {
            DiariaStatus.SemPagamento => 1,
            DiariaStatus.Pago => 2,
            DiariaStatus.Confirmado => 3,
            DiariaStatus.Concluido => 4,
            DiariaStatus.Cancelado => 5,
            DiariaStatus.Avaliado => 6,
            DiariaStatus.Transferido => 7,
            _ => throw new ArgumentOutOfRangeException(nameof(diariaStatus), diariaStatus, null)
        };
    }

    public static bool IsSemPagamento(this int diariaStatus)
    {
        return diariaStatus == (int)DiariaStatus.SemPagamento;
    }

    public static bool IsConfirmado(this int diariaStatus)
    {
        return diariaStatus == (int)DiariaStatus.Confirmado;
    }

    public static bool IsConcluido(this int diariaStatus)
    {
        return diariaStatus == (int)DiariaStatus.Concluido;
    }

    public static bool IsPago(this int diariaStatus)
    {
        return diariaStatus == (int)DiariaStatus.Pago;
    }
}