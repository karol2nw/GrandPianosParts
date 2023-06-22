

using GrandPianosParts.Entities;

namespace GrandPianosParts.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
        event EventHandler<T> ItemAdded;
        event EventHandler<T> ItemRemoved;
        event EventHandler<T> ItemSaved;

        void Open();
    }
}
