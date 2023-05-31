
using GrandPianosParts.Entities;

namespace GrandPianosParts.Repositories
{
    internal interface IReadRepository <out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

    }
}
