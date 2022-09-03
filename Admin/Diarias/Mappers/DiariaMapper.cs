using EDiaristas.Admin.Diarias.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Admin.Diarias.Mappers;

public class DiariaMapper : IDiariaMapper
{
    public DiariaSummary ToSummary(Diaria diaria)
    {
        return new DiariaSummary
        {
            Id = diaria.Id,
            Status = diaria.Status.GetDescription(),
            NomeCliente = diaria.Cliente.NomeCompleto,
            NomeDiarista = diaria.Diarista?.NomeCompleto ?? string.Empty,
            ChavePix = diaria.Diarista?.ChavePix ?? string.Empty,
            DataAtendimento = diaria.DataAtendimento.ToString("dd/MM/yyyy"),
            Preco = diaria.Preco.ToString("C"),
            Comissao = diaria.ValorComissao.ToString("C"),
            Transferencia = (diaria.Preco - diaria.ValorComissao).ToString("C")
        };
    }
}