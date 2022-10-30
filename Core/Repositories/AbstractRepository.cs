using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories;

public abstract class AbstractRepository<T> : ICrudRepository<T, int> where T : BaseModel
{
    protected readonly EDiaristasDbContext context;

    public AbstractRepository(EDiaristasDbContext eDiaristasDbContext)
    {
        context = eDiaristasDbContext;
    }

    public T Create(T model)
    {
        context.Set<T>().Add(model);
        context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var model = context.Set<T>().Find(id);
        if (model is not null)
        {
            context.Set<T>().Remove(model);
            context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return context.Set<T>().Any(e => e.Id == id);
    }

    public ICollection<T> FindAll()
    {
        return context.Set<T>().ToList();
    }

    public ICollection<T> FindAll<TKey>(Func<T, TKey> keySelector, bool? ascending = true)
    {
        if (ascending == true)
        {
            return context.Set<T>().OrderBy(keySelector).ToList();
        }
        return context.Set<T>().OrderByDescending(keySelector).ToList();
    }

    public T? FindById(int id)
    {
        return context.Set<T>().Find(id);
    }

    public T Update(T model)
    {
        context.Set<T>().Update(model);
        context.SaveChanges();
        return model;
    }
}