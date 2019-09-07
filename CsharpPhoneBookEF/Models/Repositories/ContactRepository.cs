using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using CsharpPhoneBookEF.BusinessLogic;

namespace CsharpPhoneBookEF.Models
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(DbContext db) : base(db)
        {
        }

        public List<Contact> GetAllWithString(string s)
        {
            s = s.ToLower();
            var phone = PhoneFormatting.SimplifyPhone(s);
            return _dbSet.Where(c => (c.Name.ToLower().Contains(s) || c.Family.ToLower().Contains(s) || c.Phone.Contains(phone))).ToList();
        }

        public bool PhoneExists(string s)
        {
            var phone = PhoneFormatting.SimplifyPhone(s);
            return _dbSet.Count(c => c.Phone == phone) > 0;
        }
    }
}