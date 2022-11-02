namespace EDiaristas.Core.Repositories;

public interface ICrudRepository<T, Id>
{
    ICollection<T> FindAll(params string[] includes);
    ICollection<T> FindAll<TKey>(Func<T, TKey> keySelector, bool? ascending = true, params string[] includes);
    T? FindById(Id id);
    T Create(T model);
    T Update(T model);
    void DeleteById(Id id);
    bool ExistsById(Id id);
}