using System.Security.Claims;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Repositories.Diarias;

namespace EDiaristas.Core.Permissions;

public class DiariaPermissions : IPermission<int>
{
    private readonly IDiariaRepository _diariaRepository;

    public DiariaPermissions(IDiariaRepository diariaRepository)
    {
        _diariaRepository = diariaRepository;
    }

    public void CheckPermission(ClaimsPrincipal user, int diariaId, string operation)
    {
        var clienteId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (clienteId == null)
        {
            throw new UnauthenticatedException();
        }
        if (operation == DiariaOperations.Pagar && !_diariaRepository.ExistsByIdAndClienteId(diariaId, int.Parse(clienteId)))
        {
            throw new UnauthorizedException();
        }
    }
}

public static class DiariaOperations
{
    public const string Pagar = "Pagar";
}