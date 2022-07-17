using EDiaristas.Admin.Usuarios.Dtos;
using EDiaristas.Admin.Usuarios.Mappers;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.PasswordEnconder.Adapters;
using FluentValidation;

namespace EDiaristas.Admin.Usuarios.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioMapper _usuarioMapper;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordEnconderService _passwordEnconderService;
    private readonly IValidator<UsuarioCreateForm> _usuarioCreateFormValidator;
    private readonly IValidator<UsuarioUpdateForm> _usuarioUpdateFormValidator;
    private readonly IValidator<UpdatePasswordForm> _updatePasswordFormValidator;

    public UsuarioService(
        IUsuarioMapper mapper,
        IUsuarioRepository repository,
        IValidator<UsuarioCreateForm> usuarioCreateFormValidator,
        IValidator<UsuarioUpdateForm> usuarioUpdateFormValidator,
        IValidator<UpdatePasswordForm> updatePasswordFormValidator,
        IPasswordEnconderService passwordEnconderService)
    {
        _usuarioMapper = mapper;
        _usuarioRepository = repository;
        _usuarioCreateFormValidator = usuarioCreateFormValidator;
        _usuarioUpdateFormValidator = usuarioUpdateFormValidator;
        _updatePasswordFormValidator = updatePasswordFormValidator;
        _passwordEnconderService = passwordEnconderService;
    }

    public void Create(UsuarioCreateForm form)
    {
        _usuarioCreateFormValidator.ValidateAndThrow(form);
        var usuarioToCreate = _usuarioMapper.ToModel(form);
        usuarioToCreate.TipoUsuario = TipoUsuario.Admin;
        usuarioToCreate.Senha = _passwordEnconderService.Enconde(form.Senha);
        _usuarioRepository.Create(usuarioToCreate);
    }

    public void DeleteById(int id)
    {
        if (!_usuarioRepository.ExistsById(id))
        {
            throw new UsuarioNotFoundException();
        }
        _usuarioRepository.DeleteById(id);
    }

    public ICollection<UsuarioSummary> FindAll()
    {
        return _usuarioRepository.FindByTipoUsuario(TipoUsuario.Admin)
            .Select(u => _usuarioMapper.ToSummary(u))
            .ToList();
    }

    public UsuarioUpdateForm FindById(int id)
    {
        var foundUsuario = _usuarioRepository.FindById(id);
        if (foundUsuario is null)
        {
            throw new UsuarioNotFoundException();
        }
        return _usuarioMapper.ToUpdateForm(foundUsuario);
    }

    public void UpdateById(int id, UsuarioUpdateForm form)
    {
        form.Id = id;
        _usuarioUpdateFormValidator.ValidateAndThrow(form);
        var usuarioToUpdate = _usuarioRepository.FindById(id);
        if (usuarioToUpdate is null)
        {
            throw new UsuarioNotFoundException();
        }
        usuarioToUpdate.Email = form.Email;
        usuarioToUpdate.NomeCompleto = form.NomeCompleto;
        _usuarioRepository.Update(usuarioToUpdate);
    }

    public void UpdatePassword(string email, UpdatePasswordForm form)
    {
        _updatePasswordFormValidator.ValidateAndThrow(form);
        var usuarioToUpdate = _usuarioRepository.FindByEmail(email);
        if (usuarioToUpdate is null)
        {
            throw new UsuarioNotFoundException();
        }
        if (!_passwordEnconderService.Verify(form.SenhaAntiga, usuarioToUpdate.Senha))
        {
            throw new InvalidCredentialsException();
        }
        usuarioToUpdate.Senha = _passwordEnconderService.Enconde(form.NovaSenha);
        _usuarioRepository.Update(usuarioToUpdate);
    }
}