using EDiaristas.Core.Models;

namespace EDiaristas.Api.Diarias.Dtos;

public class CandidaturaData
{
    public Diaria Diaria { get; set; }
    public Usuario Candidato { get; set; }

    public CandidaturaData(Diaria diaria, Usuario candidato)
    {
        Diaria = diaria;
        Candidato = candidato;
    }
}