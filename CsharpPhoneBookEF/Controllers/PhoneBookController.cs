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
using CsharpPhoneBookEF.Models;

namespace CsharpPhoneBookEF.Controllers
{
    public class PhoneBookController : ApiController
    {
        private readonly PhoneBookContext db = new PhoneBookContext();

        // GET: api/PhoneBook/5
        public Contact[] GetContacts(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return db.Contacts.ToArray();
            }

            return db.Contacts.Where(c => (c.Name.Contains(term) || c.Family.Contains(term) || c.Phone.Contains(term))).ToArray();
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (PhoneExists(contact.Phone))
            {
                return BadRequest();
            }

            db.Contacts.Add(contact);


            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contact.Id }, contact);
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult EditContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = db.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(c => c.Id == id) > 0;
        }

        private bool PhoneExists(string phone)
        {
            return db.Contacts.Count(c => c.Phone == phone) > 0;
        }
    }
}