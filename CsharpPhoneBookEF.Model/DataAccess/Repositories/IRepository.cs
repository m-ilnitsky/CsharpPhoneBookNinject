using System.Collections.Generic;

namespace CsharpPhoneBookEF.Model.Repositories
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(List<T> entities);
        List<T> GetAll();
        T GetById(int id);
        int GetCount();
    }
}