

using GrandPianosParts.Entities;

namespace GrandPianosParts.Repositories
{
    internal interface IWriteRepository <in T> where T : class, IEntity
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }
}
