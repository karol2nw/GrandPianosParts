
using GrandPianosParts.Entities;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace GrandPianosParts.Repositories
{
    internal class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        public event EventHandler<T> ItemAdded;
        public event EventHandler<T> ItemRemoved;
        public event EventHandler<T> ItemSaved;


        private const string filename = "JsonDataBase.json";
        

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
                    var json = JsonSerializer.Serialize<T>(item);

                    writer.WriteLine(json);
                    ItemSaved.Invoke(this, item);
                }
            }
        }

        public void Open()
        {
            if (File.Exists(filename))
            {
                using (var reader = File.OpenText(filename))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var item = JsonSerializer.Deserialize<T>(line);
                        Add(item);

                        line = reader.ReadLine();
                    }
                }
                File.WriteAllText(filename, string.Empty);
            }
            else
            {
                throw new Exception("Json file doesn't exitst");
            }
        }
    }
}
