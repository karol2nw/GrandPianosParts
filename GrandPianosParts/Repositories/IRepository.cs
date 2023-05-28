

namespace GrandPianosParts.Repositories
{
    internal interface IRepository<T> 
    {
        IEnumerable<T> GetAll();
        T GetById(int id);       
        void Add(T item);
        void Remove (T item);
        void Save();
    }
}
