using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CsharpPhoneBookEF.BusinessLogic;
using CsharpPhoneBookEF.Contracts;
using CsharpPhoneBookEF.Models;

namespace CsharpPhoneBookEF.Controllers
{
    public class PhoneBookController : ApiController
    {
        private readonly PhoneBookContext _db = new PhoneBookContext();

        // GET: api/PhoneBook/5
        public List<ContactDto> GetContacts(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return _db.Contacts.ToList().ToDto();
            }

            return _db.Contacts.Where(c => (c.Name.Contains(term) || c.Family.Contains(term) || c.Phone.Contains(term))).ToList().ToDto();
        }

        [HttpPost]
        public Object AddContact([FromBody]ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return new { Success = false, ErrorCode = ServerError.MODEL_STATE_IS_INVALID };
            }

            if (PhoneExists(contactDto.Phone))
            {
                return new { Success = false, ErrorCode = ServerError.IS_PHONE_NUMBER };
            }

            _db.Contacts.Add(contactDto.ToModel());

            _db.SaveChanges();

            return new { Success = true };
        }

        [HttpPost]
        public Object EditContact([FromBody]ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return new { Success = false, ErrorCode = ServerError.MODEL_STATE_IS_INVALID };
            }

            Contact contact = _db.Contacts.Find(contactDto.Id);

            if (contact == null)
            {
                return new { Success = false, ErrorCode = ServerError.CONTACT_NOT_FOUND };
            }

            _db.Entry(contact).State = EntityState.Modified;

            contact.Name = contactDto.Name;
            contact.Family = contactDto.Family;
            contact.Phone = contactDto.Phone;

            _db.SaveChanges();

            return new { Success = true };
        }

        [HttpPost]
        public Object DeleteContact([FromBody]int id)
        {
            Contact contact = _db.Contacts.Find(id);

            if (contact == null)
            {
                return new { Success = false, ErrorCode = ServerError.CONTACT_NOT_FOUND };
            }

            _db.Contacts.Remove(contact);
            _db.SaveChanges();

            return new { Success = true };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return _db.Contacts.Count(c => c.Id == id) > 0;
        }

        private bool PhoneExists(string phone)
        {
            return _db.Contacts.Count(c => c.Phone == phone) > 0;
        }
    }
}