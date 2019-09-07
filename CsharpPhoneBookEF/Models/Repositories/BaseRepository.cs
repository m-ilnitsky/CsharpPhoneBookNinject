using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CsharpPhoneBookEF.Models
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;
        protected DbSet<T> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _db = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public virtual void Delete(List<T> entities)
        {
            foreach (var e in entities)
            {
                Delete(e);
            }
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public int GetCount()
        {
            return _dbSet.Count();
        }
    }
}