using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using CsharpPhoneBookEF.Model.Entities;
using CsharpPhoneBookEF.Model.BusinessLogic;
using System.Data.Entity.Infrastructure;

namespace CsharpPhoneBookEF.Model.Repositories
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
            return _dbSet.Where(c => (c.Name.Contains(s) || c.Family.Contains(s) || c.Phone.Contains(phone))).ToList();
        }

        public bool PhoneExists(string s)
        {
            var phone = PhoneFormatting.SimplifyPhone(s);
            return _dbSet.Any(c => c.Phone == phone);
        }

        public virtual bool DeleteById(int id)
        {
            var contact = new Contact
            {
                Id = id
            };

            try
            {
                _dbSet.Attach(contact);
                _dbSet.Remove(contact);
                _db.SaveChanges();

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Контакт удалён ранее
                return false;
            }
        }

        public virtual int DeleteById(IEnumerable<int> ids)
        {
            var contacts = new List<Contact>();

            try
            {
                foreach (var id in ids)
                {
                    var contact = new Contact
                    {
                        Id = id
                    };

                    _dbSet.Attach(contact);
                    contacts.Add(contact);
                }

                _dbSet.RemoveRange(contacts);
                _db.SaveChanges();

                return contacts.Count;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Один или несколько контактов были удалены ранее
                return 0;
            }
        }
    }
}