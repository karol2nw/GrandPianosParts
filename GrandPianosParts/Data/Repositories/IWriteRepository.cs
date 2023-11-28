using GrandPianosParts.Data.Entities;

namespace GrandPianosParts.Data.Repositories
{
    public interface IWriteRepository<in T> where T : class, IEntity
    {
        void Add(T item);
        void Remove(T item);

        void Save();
    }
}
