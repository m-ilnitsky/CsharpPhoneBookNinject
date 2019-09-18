using System.Collections.Generic;

using CsharpPhoneBookEF.Model.Entities;

namespace CsharpPhoneBookEF.Model.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        List<Contact> GetAllWithString(string s);
        bool PhoneExists(string s);
    }
}