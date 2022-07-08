namespace EDiaristas.Core.Repositories;

public class PagedResult<Model>
{
    public ICollection<Model> Elements { get; set; } = new List<Model>();
    public int PageSize { get; set; }
    public int TotalElements { get; set; }
}