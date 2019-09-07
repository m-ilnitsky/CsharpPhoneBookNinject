using System;

namespace CsharpPhoneBookEF.Models
{
    public interface IUnitOfWork : IDisposable
    {
        T GetRepository<T>() where T : class, IRepository;
        void Save();
    }
}