using EDiaristas.Api.Avaliacoes.Dtos;
using EDiaristas.Api.Avaliacoes.Mappers;
using EDiaristas.Api.Common.Dtos;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Avaliacoes;
using EDiaristas.Core.Repositories.Diarias;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.Authentication.Adapters;
using FluentValidation;

namespace EDiaristas.Api.Avaliacoes.Services;

public class AvaliacaoService : IAvaliacaoService
{
    private readonly IDiariaRepository _diariaRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IAvaliacaoRepository _avaliacaoRepository;
    private readonly IValidator<AvaliacaoData> _avaliacaoValidator;
    private readonly ICustomAuthenticationService _authenticationService;

    public AvaliacaoService(
        IDiariaRepository diariaRepository,
        IUsuarioRepository usuarioRepository,
        IAvaliacaoRepository avaliacaoRepository,
        IValidator<AvaliacaoData> avaliacaoValidator,
        ICustomAuthenticationService authenticationService)
    {
        _diariaRepository = diariaRepository;
        _usuarioRepository = usuarioRepository;
        _avaliacaoRepository = avaliacaoRepository;
        _avaliacaoValidator = avaliacaoValidator;
        _authenticationService = authenticationService;
    }

    public MessageResponse Avaliar(AvaliacaoRequest request, int diariaId)
    {
        var diaria = _diariaRepository.FindById(diariaId);
        if (diaria is null)
        {
            throw new DiariaNotFoundException();
        }
        var avaliador = _authenticationService.GetUsuarioAutenticado();
        _avaliacaoValidator.ValidateAndThrow(new AvaliacaoData(request, diaria, avaliador));

        var avaliacao = new Avaliacao
        {
            Descricao = request.Descricao,
            Nota = request.Nota,
            Visibilidade = true,
            DiariaId = diariaId,
            AvaliadorId = avaliador.Id,
            AvaliadoId = getAvaliadoId(diaria, avaliador)
        };
        var avaliacaoCadastrada = _avaliacaoRepository.Create(avaliacao);
        atualizarStatusDaDiaria(avaliacaoCadastrada);
        atualizarReputacao(avaliacaoCadastrada);
        return new MessageResponse { Message = "Avaliação realizada com sucesso!" };
    }

    private static int getAvaliadoId(Diaria diaria, Usuario avaliador)
    {
        var avaliadoId = avaliador.TipoUsuario == TipoUsuario.Cliente
            ? diaria.DiaristaId
            : diaria.ClienteId;
        return avaliadoId ?? throw new ArgumentException("Avaliado não encontrado");
    }

    private void atualizarStatusDaDiaria(Avaliacao avaliacaoCadastrada)
    {
        var diaria = avaliacaoCadastrada.Diaria;
        if (_diariaRepository.IsAvaliada(diaria.Id))
        {
            diaria.Status = DiariaStatus.Avaliado;
            _diariaRepository.Update(diaria);
        }
    }

    private void atualizarReputacao(Avaliacao avaliacaoCadastrada)
    {
        var avaliado = avaliacaoCadastrada.Avaliado;
        var media = _avaliacaoRepository.GetAvaliacaoMedia(avaliado);
        avaliado.Reputacao = media;
        _usuarioRepository.Update(avaliado);
    }
}