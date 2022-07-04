namespace EDiaristas.Admin.Usuarios.Routes;

public static class UsuarioRoutes
{
    public const string Index = "/admin/usuarios";
    public const string Create = "/admin/usuarios/cadastrar";
    public const string UpdateById = "/admin/usuarios/{id}/editar";
    public const string DeleteById = "/admin/usuarios/{id}/excluir";
    public const string UpdatePassword = "/admin/usuarios/alterar-senha";
}