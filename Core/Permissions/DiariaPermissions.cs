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
        var usuarioId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (usuarioId == null)
        {
            throw new UnauthenticatedException();
        }
        if (operation == DiariaOperations.Pagar && !_diariaRepository.ExistsByIdAndClienteId(diariaId, int.Parse(usuarioId)))
        {
            throw new UnauthorizedException();
        }
        if (operation == DiariaOperations.Detalhar)
        {
            var hasPermission = _diariaRepository.ExistsByIdAndClienteId(diariaId, int.Parse(usuarioId))
                || _diariaRepository.ExistsByIdAndDiaristaId(diariaId, int.Parse(usuarioId));

            if (!hasPermission)
            {
                throw new UnauthorizedException();
            }
        }
    }
}

public static class DiariaOperations
{
    public const string Pagar = "Pagar";
    public const string Detalhar = "Detalhar";
}