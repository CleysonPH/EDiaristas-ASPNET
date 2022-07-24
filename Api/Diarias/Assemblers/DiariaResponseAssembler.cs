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
        var pagarDiariaLink = new LinkResponse
        {
            Type = HttpMethods.Post,
            Rel = "pagar_diaria",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Diarias.PagarName, new { DiariaId = resource.Id })
        };

        resource.AddLinkIf(resource.Status.IsSemPagamento(), pagarDiariaLink);
        return resource;
    }
}