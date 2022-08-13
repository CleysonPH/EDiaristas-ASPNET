using EDiaristas.Api.Common.Assemblers;
using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Api.Oportunidades.Dtos;

namespace EDiaristas.Api.Oportunidades.Assemblers;

public class OportunidadeResponseAssembler : IAssembler<OportunidadeResponse>
{
    private readonly LinkGenerator _linkGenerator;

    public OportunidadeResponseAssembler(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    public OportunidadeResponse ToResource(OportunidadeResponse resource, HttpContext context)
    {
        var candidatarDiariaLink = new LinkResponse
        {
            Type = HttpMethods.Post,
            Rel = "candidatar_diaria",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Diarias.CandidatarName, new { DiariaId = resource.Id })
        };
        resource.AddLink(candidatarDiariaLink);
        return resource;
    }
}