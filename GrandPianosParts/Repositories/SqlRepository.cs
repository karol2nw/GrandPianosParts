

using GrandPianosParts.Data;
using GrandPianosParts.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrandPianosParts.Repositories
{
    internal class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        public event EventHandler<T> ItemAdded;
        public event EventHandler<T> ItemRemoved;
        public event EventHandler<T> ItemSaved;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            ItemRemoved?.Invoke(this, item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Open()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                List<Hammer> hammers = dbContext.Hammers.ToList();
                List<Schank> schanks = dbContext.Schanks.ToList();
                List<DamperFilz> dampers = dbContext.DamperFilzs.ToList();
            }
        }
    }
}

