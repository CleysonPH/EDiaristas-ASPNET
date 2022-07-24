using System.Security.Claims;

namespace EDiaristas.Core.Permissions;

public interface IPermission<R>
{
    void CheckPermission(ClaimsPrincipal user, R resource, string operation);
}