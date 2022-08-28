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

        if (operation == DiariaOperations.Pagar)
        {
            if (isClienteDonoDaDiaria(diariaId, int.Parse(usuarioId)))
            {
                throw new UnauthorizedException();
            }
        }
        else if (operation == DiariaOperations.ConfirmarPresenca)
        {
            if (!isClienteDonoDaDiaria(diariaId, int.Parse(usuarioId)))
            {
                throw new UnauthorizedException();
            }
        }
        else if (operation == DiariaOperations.Detalhar)
        {
            if (!isDiaristaOuClienteDonoDaDiaria(diariaId, int.Parse(usuarioId)))
            {
                throw new UnauthorizedException();
            }
        }
        else if (operation == DiariaOperations.Avaliar)
        {
            if (!isDiaristaOuClienteDonoDaDiaria(diariaId, int.Parse(usuarioId)))
            {
                throw new UnauthorizedException();
            }
        }
        else if (operation == DiariaOperations.Cancelar)
        {
            if (!isDiaristaOuClienteDonoDaDiaria(diariaId, int.Parse(usuarioId)))
            {
                throw new UnauthorizedException();
            }
        }
    }

    private bool isDiaristaOuClienteDonoDaDiaria(int diariaId, int usuarioId)
    {
        return _diariaRepository.ExistsByIdAndClienteId(diariaId, usuarioId)
            || _diariaRepository.ExistsByIdAndDiaristaId(diariaId, usuarioId);
    }

    private bool isClienteDonoDaDiaria(int diariaId, int usuarioId)
    {
        return !_diariaRepository.ExistsByIdAndClienteId(diariaId, usuarioId);
    }

}

public static class DiariaOperations
{
    public const string Pagar = "Pagar";
    public const string Detalhar = "Detalhar";
    public const string ConfirmarPresenca = "ConfirmarPresenca";
    public const string Avaliar = "Avaliar";
    public const string Cancelar = "Cancelar";
}