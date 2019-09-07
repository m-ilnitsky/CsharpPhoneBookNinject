using System;
using System.Data.Entity;

namespace CsharpPhoneBookEF.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _db;

        public UnitOfWork(DbContext dbContext)
        {
            _db = dbContext;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public T GetRepository<T>() where T : class, IRepository
        {
            if (typeof(T) == typeof(IContactRepository))
            {
                return new ContactRepository(_db) as T;
            }

            throw new Exception("Неизвестный тип репозитория: " + typeof(T));
        }
    }
}