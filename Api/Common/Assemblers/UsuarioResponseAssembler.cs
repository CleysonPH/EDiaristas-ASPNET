using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Common.Routes;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Common.Assemblers;

public class UsuarioResponseAssembler : IAssembler<UsuarioResponse>
{
    private readonly LinkGenerator _linkGenerator;

    public UsuarioResponseAssembler(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    public UsuarioResponse ToResource(UsuarioResponse resource, HttpContext context)
    {
        var cadastrarDiariaLink = new LinkResponse
        {
            Type = HttpMethods.Post,
            Rel = "cadastrar_diaria",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Diarias.CadastrarName, new { })
        };
        var listarDiariasLink = new LinkResponse
        {
            Type = HttpMethods.Get,
            Rel = "listar_diarias",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Diarias.ListarName, new { })
        };
        resource.AddLinkIf(resource.TipoUsuario.IsCliente(), cadastrarDiariaLink);
        resource.AddLink(listarDiariasLink);
        return resource;
    }
}