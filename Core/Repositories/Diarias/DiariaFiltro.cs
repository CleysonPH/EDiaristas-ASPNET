using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Diarias;

public class DiariaFiltro
{
    public string ClienteNome { get; set; } = string.Empty;
    public ICollection<DiariaStatus> Statuses { get; set; } = new List<DiariaStatus>();
}