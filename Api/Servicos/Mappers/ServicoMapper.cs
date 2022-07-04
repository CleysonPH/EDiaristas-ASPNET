using EDiaristas.Api.Servicos.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Servicos.Mappers;

public class ServicoMapper : IServicoMapper
{
    public ServicoResponse ToResponse(Servico servico)
    {
        return new ServicoResponse
        {
            Id = servico.Id,
            Nome = servico.Nome,
            ValorMinimo = servico.ValorMinimo,
            QtdHoras = servico.QtdHoras,
            PorcentagemComissao = servico.PorcentagemComissao,
            HorasQuarto = servico.HorasQuarto,
            ValorQuarto = servico.ValorQuarto,
            HorasSala = servico.HorasSala,
            ValorSala = servico.ValorSala,
            HorasBanheiro = servico.HorasBanheiro,
            ValorBanheiro = servico.ValorBanheiro,
            HorasCozinha = servico.HorasCozinha,
            ValorCozinha = servico.ValorCozinha,
            HorasQuintal = servico.HorasQuintal,
            ValorQuintal = servico.ValorQuintal,
            HorasOutros = servico.HorasOutros,
            ValorOutros = servico.ValorOutros,
            Icone = servico.Icone.ToName(),
            Posicao = servico.Posicao
        };
    }
}