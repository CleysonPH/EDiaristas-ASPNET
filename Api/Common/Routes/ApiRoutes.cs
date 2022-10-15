namespace EDiaristas.Api.Common.Routes;

public static class ApiRoutes
{
    public static class Home
    {
        public const string Index = "/api";
        public const string IndexName = "Home";
    }

    public static class Diaristas
    {
        public const string BuscarDiaristasPorCep = "/api/diaristas/localidades";
        public const string BuscarDiaristasPorCepName = "BuscarDiaristasPorCep";
        public const string VerificarDisponibilidadePorCep = "/api/diaristas/disponibilidade";
        public const string VerificarDisponibilidadePorCepName = "VerificarDisponibilidadePorCep";
    }

    public static class Me
    {
        public const string ExibirUsuarioAutenticado = "/api/me";
        public const string ExibirUsuarioAutenticadoName = "ExibirUsuarioAutenticado";
    }

    public static class Servicos
    {
        public const string FindAll = "/api/servicos";
        public const string FindAllName = "ListarSevicos";
    }

    public static class Enderecos
    {
        public const string BuscarEnderecoPorCep = "/api/enderecos";
        public const string BuscarEnderecoPorCepName = "BuscarEnderecoPorCep";
    }

    public static class Usuarios
    {
        public const string CadastrarUsuario = "/api/usuarios";
        public const string CadastrarUsuarioName = "CadastrarUsuario";
        public const string AtualizarUsuario = "/api/usuarios";
        public const string AtualizarUsuarioName = "AtualizarUsuario";
        public const string AtualizarFotoUsuario = "/api/usuarios/foto";
        public const string AtualizarFotoUsuarioName = "AtualizarFotoUsuario";
    }

    public static class Auth
    {
        public const string Token = "/auth/token";
        public const string TokenName = "Token";
        public const string Refresh = "auth/refresh";
        public const string RefreshName = "Refresh";
        public const string Logout = "auth/logout";
        public const string LogoutName = "Logout";
    }

    public static class Diarias
    {
        public const string Cadastrar = "/api/diarias";
        public const string CadastrarName = "CadastrarDiaria";
        public const string Listar = "/api/diarias";
        public const string ListarName = "ListarDiarias";
        public const string BuscarPorId = "/api/diarias/{diariaId}";
        public const string BuscarPorIdName = "BuscarDiariaPorId";
        public const string Pagar = "/api/diarias/{diariaId}/pagar";
        public const string PagarName = "PagarDiaria";
        public const string Candidatar = "/api/diarias/{diariaId}/candidatar";
        public const string CandidatarName = "Candidatar";
        public const string ConfirmarPresenca = "/api/diarias/{diariaId}/confirmar-presenca";
        public const string ConfirmarPresencaName = "ConfirmarPresenca";
        public const string Cancelar = "/api/diarias/{diariaId}/cancelar";
        public const string CancelarName = "CancelarDiaria";
    }

    public static class EnderecosDiarista
    {
        public const string AtualizarEndereco = "/api/usuarios/endereco";
        public const string AtualizarEnderecoName = "AtualizarEndereco";
        public const string ObterEnderecoUsuarioLogado = "/api/usuarios/endereco";
        public const string ObterEnderecoUsuarioLogadoName = "ObterEnderecoUsuarioLogado";
    }

    public static class CidadeAtendida
    {
        public const string ListarPorUsuarioLogado = "/api/usuarios/cidades-atendidas";
        public const string ListarPorUsuarioLogadoName = "ListarPorUsuarioLogado";
        public const string Atualizar = "/api/usuarios/cidades-atendidas";
        public const string AtualizarName = "AtualizarCidadeAtendida";
    }

    public static class Oportunidade
    {
        public const string BuscarOportunidades = "/api/oportunidades";
        public const string BuscarOportunidadesName = "BuscarOportunidades";
    }

    public static class Avaliacao
    {
        public const string Avaliar = "/api/diarias/{diariaId}/avaliacao";
        public const string AvaliarName = "AvaliarDiaria";
    }

    public static class Pagamentos
    {
        public const string Listar = "/api/pagamentos";
        public const string ListarName = "ListarPagamentos";
    }
}