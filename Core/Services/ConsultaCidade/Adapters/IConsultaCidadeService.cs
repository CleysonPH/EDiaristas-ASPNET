namespace EDiaristas.Core.Services.ConsultaCidade.Adapters;

public interface IConsultaCidadeService
{
    ConsultaCidadeResult BuscarCidadePorCodigoIbge(string codigoIbge);
}