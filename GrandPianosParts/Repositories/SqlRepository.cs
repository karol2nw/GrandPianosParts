

using GrandPianosParts.Entities;

namespace GrandPianosParts.Repositories
{
    internal class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()

    {
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

