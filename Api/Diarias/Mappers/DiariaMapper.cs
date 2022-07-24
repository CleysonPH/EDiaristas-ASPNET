using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Diarias.Mappers;

public class DiariaMapper : IDiariaMapper
{

    public Diaria ToModel(DiariaRequest request)
    {
        return new Diaria
        {
            DataAtendimento = request.DataAtendimento,
            TempoAtendimento = request.TempoAtendimento,
            Preco = request.Preco,
            Logradouro = request.Logradouro,
            Numero = request.Numero,
            Bairro = request.Bairro,
            Complemento = request.Complemento,
            Cidade = request.Cidade,
            Estado = request.Estado,
            Cep = request.Cep,
            CodigoIbge = request.CodigoIbge,
            QuantidadeQuartos = request.QuantidadeQuartos,
            QuantidadeSalas = request.QuantidadeSalas,
            QuantidadeCozinhas = request.QuantidadeCozinhas,
            QuantidadeBanheiros = request.QuantidadeBanheiros,
            QuantidadeQuintais = request.QuantidadeQuintais,
            QuantidadeOutros = request.QuantidadeOutros,
            Observacoes = request.Observacoes,
            ServicoId = request.Servico
        };
    }

    public DiariaResponse ToResponse(Diaria diaria)
    {
        return new DiariaResponse
        {
            Id = diaria.Id,
            Status = diaria.Status.ToDiariaStatusInt(),
            MotivoCancelamento = diaria.MotivoCancelamento,
            NomeServico = diaria.Servico?.Nome,
            Complemento = diaria.Complemento,
            DataAtendimento = diaria.DataAtendimento,
            TempoAtendimento = diaria.TempoAtendimento,
            Preco = diaria.Preco,
            Logradouro = diaria.Logradouro,
            Numero = diaria.Numero,
            Bairro = diaria.Bairro,
            Estado = diaria.Estado,
            Cidade = diaria.Cidade,
            CodigoIbge = diaria.CodigoIbge,
            QuantidadeQuartos = diaria.QuantidadeQuartos,
            QuantidadeSalas = diaria.QuantidadeSalas,
            QuantidadeCozinhas = diaria.QuantidadeCozinhas,
            QuantidadeBanheiros = diaria.QuantidadeBanheiros,
            QuantidadeQuintais = diaria.QuantidadeQuintais,
            QuantidadeOutros = diaria.QuantidadeOutros,
            Observacoes = diaria.Observacoes,
            Servico = diaria.ServicoId,
            Cliente = UsuarioToUsuarioDiariaResponse(diaria.Cliente),
            Diarista = UsuarioToUsuarioDiariaResponse(diaria.Diarista)
        };
    }

    private UsuarioDiariaResponse? UsuarioToUsuarioDiariaResponse(Usuario? usuario)
    {
        if (usuario == null)
        {
            return null;
        }
        return new UsuarioDiariaResponse
        {
            Id = usuario.Id,
            NomeCompleto = usuario.NomeCompleto,
            Nascimento = usuario.Nascimento,
            Telefone = usuario.Telefone,
            TipoUsuario = usuario.TipoUsuario.ToTipoUsuarioInt(),
            Reputacao = usuario.Reputacao
        };
    }
}