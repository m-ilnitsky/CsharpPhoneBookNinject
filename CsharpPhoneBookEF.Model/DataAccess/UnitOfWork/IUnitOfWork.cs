using System;

namespace CsharpPhoneBookEF.Model.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        T GetRepository<T>() where T : class, IRepository;
        void Save();
    }
}