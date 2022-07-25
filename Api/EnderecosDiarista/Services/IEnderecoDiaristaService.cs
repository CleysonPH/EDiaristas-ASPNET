using EDiaristas.Api.EnderecosDiarista.Dtos;

namespace EDiaristas.Api.EnderecosDiarista.Services;

public interface IEnderecoDiaristaService
{
    EnderecoDiaristaResponse AlterarEndereco(EnderecoDiaristaRequest request);
    EnderecoDiaristaResponse ObterEnderecoUsuarioLogado();
}