using EDiaristas.Api.Common.Assemblers;
using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Avaliacoes;
using EDiaristas.Core.Services.Authentication.Adapters;

namespace EDiaristas.Api.Diarias.Assemblers;

public class DiariaResponseAssembler : IAssembler<DiariaResponse>
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IAvaliacaoRepository _avaliacaoRepository;
    private readonly ICustomAuthenticationService _authenticationService;

    public DiariaResponseAssembler(
        LinkGenerator linkGenerator,
        IAvaliacaoRepository avaliacaoRepository,
        ICustomAuthenticationService authenticationService)
    {
        _linkGenerator = linkGenerator;
        _avaliacaoRepository = avaliacaoRepository;
        _authenticationService = authenticationService;
    }

    public DiariaResponse ToResource(DiariaResponse resource, HttpContext context)
    {
        var selfLink = new LinkResponse
        {
            Type = HttpMethods.Get,
            Rel = "self",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Diarias.BuscarPorIdName, new { DiariaId = resource.Id })
        };
        var pagarDiariaLink = new LinkResponse
        {
            Type = HttpMethods.Post,
            Rel = "pagar_diaria",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Diarias.PagarName, new { DiariaId = resource.Id })
        };
        var confirmarDiaristaLink = new LinkResponse
        {
            Type = HttpMethods.Patch,
            Rel = "confirmar_diarista",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Diarias.ConfirmarPresencaName, new { DiariaId = resource.Id })
        };
        var avaliarDiariaLink = new LinkResponse
        {
            Type = HttpMethods.Patch,
            Rel = "avaliar_diaria",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Avaliacao.AvaliarName, new { DiariaId = resource.Id })
        };
        var cancelarDiariaLink = new LinkResponse
        {
            Type = HttpMethods.Patch,
            Rel = "cancelar_diaria",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Diarias.CancelarName, new { DiariaId = resource.Id })
        };

        resource.AddLink(selfLink);
        resource.AddLinkIf(resource.Status.IsSemPagamento(), pagarDiariaLink);
        resource.AddLinkIf(isAptaParaConfirmarPresenca(resource), confirmarDiaristaLink);
        resource.AddLinkIf(isAptaParaAvaliacao(resource), avaliarDiariaLink);
        resource.AddLinkIf(isAptaParaCancelamento(resource), cancelarDiariaLink);

        return resource;
    }

    private bool isAptaParaAvaliacao(DiariaResponse resource)
    {
        return resource.Status.IsConcluido()
            && !_avaliacaoRepository.ExistsByAvaliadorIdAndDiariaId(_authenticationService.GetUsuarioAutenticado().Id, resource.Id);
    }

    private bool isAptaParaConfirmarPresenca(DiariaResponse resource)
    {
        return resource.Status.IsConfirmado()
            && resource.DataAtendimento < DateTime.Now
            && resource.Diarista != null;
    }

    private bool isAptaParaCancelamento(DiariaResponse resource)
    {
        return (resource.Status.IsPago() || resource.Status.IsConfirmado())
            && resource.DataAtendimento > DateTime.Now;
    }
}