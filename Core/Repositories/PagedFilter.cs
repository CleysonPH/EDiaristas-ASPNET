namespace EDiaristas.Core.Repositories;

public class PagedFilter
{
    public int Page { get; set; }
    public int PageSize { get; set; }

    public PagedFilter(int page, int pageSize)
    {
        Page = page > 0 ? page : 1;
        PageSize = pageSize > 0 ? pageSize : 10;
    }
}