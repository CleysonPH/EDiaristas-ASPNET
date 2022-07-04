using EDiaristas.Admin.Servicos.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Admin.Servicos.Mappers;

public class ServicoMapper : IServicoMapper
{
    public ServicoForm ToForm(Servico servico)
    {
        return new ServicoForm
        {
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
            Icone = (int)servico.Icone,
            Posicao = servico.Posicao
        };
    }

    public Servico ToModel(ServicoForm form)
    {
        return new Servico
        {
            Nome = form.Nome,
            ValorMinimo = form.ValorMinimo,
            QtdHoras = form.QtdHoras,
            PorcentagemComissao = form.PorcentagemComissao,
            HorasQuarto = form.HorasQuarto,
            ValorQuarto = form.ValorQuarto,
            HorasSala = form.HorasSala,
            ValorSala = form.ValorSala,
            HorasBanheiro = form.HorasBanheiro,
            ValorBanheiro = form.ValorBanheiro,
            HorasCozinha = form.HorasCozinha,
            ValorCozinha = form.ValorCozinha,
            HorasQuintal = form.HorasQuintal,
            ValorQuintal = form.ValorQuintal,
            HorasOutros = form.HorasOutros,
            ValorOutros = form.ValorOutros,
            Icone = form.Icone.ToIcone(),
            Posicao = form.Posicao
        };
    }

    public ServicoSummary ToSummary(Servico servico)
    {
        return new ServicoSummary
        {
            Id = servico.Id,
            Nome = servico.Nome,
            ValorMinimo = servico.ValorMinimo
        };
    }
}