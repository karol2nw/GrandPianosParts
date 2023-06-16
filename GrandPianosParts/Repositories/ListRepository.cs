
using GrandPianosParts.Entities;
using System.Text.Json;

namespace GrandPianosParts.Repositories
{
    internal class ListRepository<T> : IRepository<T> where T : class , IEntity , new()
    {
       public event EventHandler<T> ItemAdded;
       public event EventHandler<T> ItemRemoved;
       
        private const string filename = "filename.json";   
        
        private readonly List<T> _items = new();


        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            ItemAdded.Invoke(this, item);
        }

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
            ItemRemoved.Invoke(this, item);
        }

        public void Save()
        {
            using (var writer = File.AppendText(filename))
            {
                foreach (var item in _items)
                {
                    JsonSerializer.Serialize(item);
                }

            }
          
                              
        }
    }
}
