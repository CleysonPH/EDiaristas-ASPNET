using EDiaristas.Api.Common.Assemblers;
using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Home.Dtos;
using EDiaristas.Api.Common.Routes;

namespace EDiaristas.Api.Home.Assemblers;

public class HomeAssembler : IAssembler<HomeResponse>
{
    private readonly LinkGenerator _linkGenerator;

    public HomeAssembler(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    public HomeResponse ToResource(HomeResponse resource, HttpContext context)
    {
        var listarServicosLink = new LinkResponse
        {
            Type = HttpMethods.Get,
            Rel = "listar_servicos",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Servicos.FindAllName, new { })
        };
        var enderecoLink = new LinkResponse
        {
            Type = HttpMethods.Get,
            Rel = "endereco_cep",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Enderecos.BuscarEnderecoPorCepName, new { })
        };
        var diaristasCidadeLink = new LinkResponse
        {
            Type = HttpMethods.Get,
            Rel = "diaristas_cidade",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Diaristas.BuscarDiaristasPorCepName, new { })
        };
        var verificarDisponibilidadeAtendimentoLink = new LinkResponse
        {
            Type = HttpMethods.Get,
            Rel = "verificar_disponibilidade_atendimento",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Diaristas.VerificarDisponibilidadePorCepName, new { })
        };
        var cadastrarUsuarioLink = new LinkResponse
        {
            Type = HttpMethods.Post,
            Rel = "cadastrar_usuario",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Usuarios.CadastrarUsuarioName, new { })
        };
        var loginLink = new LinkResponse
        {
            Type = HttpMethods.Post,
            Rel = "login",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Auth.TokenName, new { })
        };
        var usuarioLogadoLink = new LinkResponse
        {
            Type = HttpMethods.Get,
            Rel = "usuario_logado",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Me.ExibirUsuarioAutenticadoName, new { })
        };
        var logoutLink = new LinkResponse
        {
            Type = HttpMethods.Post,
            Rel = "logout",
            Uri = _linkGenerator.GetUriByName(context, ApiRoutes.Auth.LogoutName, new { })
        };

        resource.AddLinks(
            listarServicosLink,
            enderecoLink,
            diaristasCidadeLink,
            verificarDisponibilidadeAtendimentoLink,
            cadastrarUsuarioLink,
            loginLink,
            usuarioLogadoLink,
            logoutLink
        );
        return resource;
    }
}