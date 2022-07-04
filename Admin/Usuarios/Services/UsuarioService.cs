using EDiaristas.Admin.Usuarios.Dtos;
using EDiaristas.Admin.Usuarios.Mappers;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Usuarios;
using FluentValidation;

namespace EDiaristas.Admin.Usuarios.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioMapper _usuarioMapper;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IValidator<UsuarioCreateForm> _usuarioCreateFormValidator;
    private readonly IValidator<UsuarioUpdateForm> _usuarioUpdateFormValidator;
    private readonly IValidator<UpdatePasswordForm> _updatePasswordFormValidator;

    public UsuarioService(
        IUsuarioMapper mapper,
        IUsuarioRepository repository,
        IValidator<UsuarioCreateForm> usuarioCreateFormValidator,
        IValidator<UsuarioUpdateForm> usuarioUpdateFormValidator,
        IValidator<UpdatePasswordForm> updatePasswordFormValidator)
    {
        _usuarioMapper = mapper;
        _usuarioRepository = repository;
        _usuarioCreateFormValidator = usuarioCreateFormValidator;
        _usuarioUpdateFormValidator = usuarioUpdateFormValidator;
        _updatePasswordFormValidator = updatePasswordFormValidator;
    }

    public void Create(UsuarioCreateForm form)
    {
        _usuarioCreateFormValidator.ValidateAndThrow(form);
        var usuarioToCreate = _usuarioMapper.ToModel(form);
        var createdUsuario = _usuarioRepository.Create(usuarioToCreate);
        _usuarioRepository.AddRole(createdUsuario.Email, Roles.Admin);
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
        return _usuarioRepository.FindAll()
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
        usuarioToUpdate.UserName = form.Email;
        usuarioToUpdate.Email = form.Email;
        usuarioToUpdate.NomeCompleto = form.NomeCompleto;
        _usuarioRepository.Update(usuarioToUpdate);
    }

    public void UpdatePassword(string email, UpdatePasswordForm form)
    {
        _updatePasswordFormValidator.ValidateAndThrow(form);
        if (!_usuarioRepository.ExistsByEmail(email))
        {
            throw new UsuarioNotFoundException();
        }
        if (!_usuarioRepository.CheckPassword(email, form.SenhaAntiga))
        {
            throw new InvalidCredentialsException();
        }
        _usuarioRepository.UpdatePassword(email, form.SenhaAntiga, form.NovaSenha);
    }
}