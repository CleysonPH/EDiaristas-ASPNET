namespace EDiaristas.Admin.Common.Routes;

public static class AdminRoutes
{
    public static class Servicos
    {
        public const string Index = "/admin/servicos";
        public const string IndexName = "ServicosIndex";
        public const string Create = "/admin/servicos/cadastrar";
        public const string CreateName = "ServicosCreate";
        public const string UpdateById = "/admin/servicos/{id}/editar";
        public const string UpdateByIdName = "ServicosUpdateById";
        public const string DeleteById = "/admin/servicos/{id}/excluir";
        public const string DeleteByIdName = "ServicosDeleteById";
    }

    public static class Auth
    {
        public const string Login = "/admin/login";
        public const string LoginName = "AdminLogin";
        public const string Logout = "/admin/logout";
        public const string LogoutName = "AdminLogout";
    }

    public static class Usuarios
    {
        public const string Index = "/admin/usuarios";
        public const string IndexName = "UsuariosIndex";
        public const string Create = "/admin/usuarios/cadastrar";
        public const string CreateName = "UsuariosCreate";
        public const string UpdateById = "/admin/usuarios/{id}/editar";
        public const string UpdateByIdName = "UsuariosUpdateById";
        public const string DeleteById = "/admin/usuarios/{id}/excluir";
        public const string DeleteByIdName = "UsuariosDeleteById";
        public const string UpdatePassword = "/admin/usuarios/alterar-senha";
        public const string UpdatePasswordName = "UsuariosUpdatePassword";
    }

    public static class Diarias
    {
        public const string Index = "/admin/diarias";
        public const string IndexName = "DiariasIndex";
        public const string MarcarComoTransferida = "/admin/diarias/{diariaId}/transferir";
        public const string MarcarComoTransferidaName = "DiariasMarcarComoTransferida";
    }
}