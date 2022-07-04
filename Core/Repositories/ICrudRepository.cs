namespace EDiaristas.Core.Repositories;

public interface ICrudRepository<Model, Id>
{
    ICollection<Model> FindAll();
    Model? FindById(Id id);
    Model Create(Model model);
    Model Update(Model model);
    void DeleteById(Id id);
    bool ExistsById(Id id);
}