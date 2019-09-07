using System.Collections.Generic;

namespace CsharpPhoneBookEF.Models
{
    public interface IContactRepository : IRepository<Contact>
    {
        List<Contact> GetAllWithString(string s);
        bool PhoneExists(string s);
    }
}