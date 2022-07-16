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
    }

    public static class Auth
    {
        public const string Token = "/api/auth/token";
        public const string TokenName = "Token";
    }
}