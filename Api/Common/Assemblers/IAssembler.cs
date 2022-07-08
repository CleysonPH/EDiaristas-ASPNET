using EDiaristas.Api.Common.Dtos;

namespace EDiaristas.Api.Common.Assemblers;

public interface IAssembler<R> where R : ResourceResponse
{
    R ToResource(R resource, HttpContext context);
    ICollection<R> ToResourceCollection(ICollection<R> resources, HttpContext context)
    {
        return resources.Select(r => ToResource(r, context)).ToList();
    }
}