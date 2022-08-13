using EDiaristas.Api.Common.Assemblers;
using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Diarias.Assemblers;

public class DiariaResponseAssembler : IAssembler<DiariaResponse>
{
    private readonly LinkGenerator _linkGenerator;

    public DiariaResponseAssembler(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
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
        var confirmarPresencaLink = new LinkResponse
        {
            Type = HttpMethods.Patch,
            Rel = "confirmar_presenca",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Diarias.ConfirmarPresencaName, new { DiariaId = resource.Id })
        };

        resource.AddLink(selfLink);
        resource.AddLinkIf(resource.Status.IsSemPagamento(), pagarDiariaLink);
        resource.AddLinkIf(isAptaParaConfirmarPresenca(resource), confirmarPresencaLink);
        return resource;
    }

    private bool isAptaParaConfirmarPresenca(DiariaResponse resource)
    {
        return resource.Status.IsConfirmado()
            && resource.DataAtendimento < DateTime.Now
            && resource.Diarista != null;
    }
}