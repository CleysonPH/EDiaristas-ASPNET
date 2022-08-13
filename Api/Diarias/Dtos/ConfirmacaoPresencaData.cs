using EDiaristas.Core.Models;

namespace EDiaristas.Api.Diarias.Dtos;

public class ConfirmacaoPresencaData
{
    public Diaria Diaria { get; set; }

    public ConfirmacaoPresencaData(Diaria diaria)
    {
        Diaria = diaria;
    }
}