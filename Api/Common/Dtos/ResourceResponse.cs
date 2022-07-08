namespace EDiaristas.Api.Common.Dtos;

public class ResourceResponse
{
    public ICollection<LinkResponse> Links { get; } = new List<LinkResponse>();

    public void AddLink(LinkResponse link)
    {
        Links.Add(link);
    }

    public void AddLinks(params LinkResponse[] links)
    {
        links.ToList().ForEach(l => Links.Add(l));
    }

    public void AddLinkIf(bool condition, LinkResponse link)
    {
        if (condition)
        {
            Links.Add(link);
        }
    }

    public void AddLinksIf(bool condition, params LinkResponse[] links)
    {
        if (condition)
        {
            links.ToList().ForEach(l => Links.Add(l));
        }
    }
}