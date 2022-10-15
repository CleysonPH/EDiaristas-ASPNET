using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.Authentication.Adapters;
using EDiaristas.Core.Services.Storage.Adapters;
using FluentValidation;

namespace EDiaristas.Api.Usuarios.Services;

public class FotoUsuarioService : IFotoUsuarioService
{
    private readonly IStorageService _storageService;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ICustomAuthenticationService _authenticationService;
    private readonly IValidator<AtualizarFotoRequest> _atualizarFotoValidator;

    public FotoUsuarioService(
        IStorageService storageService,
        IUsuarioRepository usuarioRepository,
        ICustomAuthenticationService authenticationService,
        IValidator<AtualizarFotoRequest> atualizarFotoValidator)
    {
        _storageService = storageService;
        _usuarioRepository = usuarioRepository;
        _authenticationService = authenticationService;
        _atualizarFotoValidator = atualizarFotoValidator;
    }

    public MessageResponse AtualizarFotoUsuario(AtualizarFotoRequest request)
    {
        _atualizarFotoValidator.ValidateAndThrow(request);
        var usuario = _authenticationService.GetUsuarioAutenticado();
        var fotoUrl = _storageService.UploadFile(
            fileName: request.FotoUsuario.FileName,
            contentType: request.FotoUsuario.ContentType,
            fileStream: request.FotoUsuario.OpenReadStream());
        usuario.FotoUsuario = fotoUrl;
        _usuarioRepository.Update(usuario);
        return new MessageResponse("Foto atualizada com sucesso");
    }
}