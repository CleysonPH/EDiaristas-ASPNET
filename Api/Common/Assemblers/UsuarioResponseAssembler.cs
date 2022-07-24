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
        var atualizarEnderecoLink = new LinkResponse
        {
            Type = HttpMethods.Put,
            Rel = "atualizar_endereco",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.EnderecosDiarista.AtualizarEnderecoName, new { })
        };
        var listarEnderecoLink = new LinkResponse
        {
            Type = HttpMethods.Get,
            Rel = "listar_endereco",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.EnderecosDiarista.ObterEnderecoUsuarioLogadoName, new { })
        };
        resource.AddLinkIf(resource.TipoUsuario.IsCliente(), cadastrarDiariaLink);
        resource.AddLinksIf(resource.TipoUsuario.IsDiarista(), atualizarEnderecoLink, listarEnderecoLink);
        resource.AddLink(listarDiariasLink);
        return resource;
    }
}