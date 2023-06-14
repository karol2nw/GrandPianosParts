
using GrandPianosParts.Entities;

namespace GrandPianosParts.Repositories
{
    public interface IReadRepository <out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

    }
}
