using System;
using System.Collections.Generic;
using System.Web.Http;
using CsharpPhoneBookEF.BusinessLogic;
using CsharpPhoneBookEF.Contracts;
using CsharpPhoneBookEF.Models;

namespace CsharpPhoneBookEF.Controllers
{
    public class PhoneBookController : ApiController
    {
        private readonly UnitOfWork _uow;
        private readonly ContactRepository _contactRepository;

        public PhoneBookController()
        {
            _uow = new UnitOfWork(new PhoneBookContext());
            _contactRepository = (ContactRepository)_uow.GetRepository<IContactRepository>();
        }

        // GET: api/PhoneBook/getContacts? term = +7913
        public List<ContactDto> GetContacts(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return _contactRepository.GetAll().ToDto();
            }

            return _contactRepository.GetAllWithString(term).ToDto();
        }

        [HttpPost]
        public Object AddContact([FromBody]ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return new { Success = false, ErrorCode = ServerError.MODEL_STATE_IS_INVALID };
            }

            if (_contactRepository.PhoneExists(contactDto.Phone))
            {
                return new
                {
                    Success = false,
                    ErrorCode = ServerError.IS_PHONE_NUMBER,
                    Message = "Такой номер уже имеется на сервере"
                };
            }

            _contactRepository.Create(contactDto.ToModel());
            _contactRepository.Save();

            return new { Success = true };
        }

        [HttpPost]
        public Object EditContact([FromBody]ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return new { Success = false, ErrorCode = ServerError.MODEL_STATE_IS_INVALID };
            }

            Contact contact = _contactRepository.GetById(contactDto.Id);

            if (contact == null)
            {
                return new
                {
                    Success = false,
                    ErrorCode = ServerError.CONTACT_NOT_FOUND,
                    Message = "Контакт не найден!"
                };
            }

            var changedContact = contactDto.ToModel();

            contact.Name = changedContact.Name;
            contact.Family = changedContact.Family;
            contact.Phone = changedContact.Phone;

            _contactRepository.Update(contact);
            _contactRepository.Save();

            return new { Success = true };
        }

        [HttpPost]
        public Object DeleteContact([FromBody]int id)
        {
            Contact contact = _contactRepository.GetById(id);

            if (contact == null)
            {
                return new
                {
                    Success = false,
                    ErrorCode = ServerError.CONTACT_NOT_FOUND,
                    Message = "Контакт не найден!"
                };
            }

            _contactRepository.Delete(contact);
            _contactRepository.Save();

            return new { Success = true };
        }

        [HttpPost]
        public Object DeleteContacts([FromBody]List<int> ids)
        {
            var contacts = new List<Contact>();

            foreach (var id in ids)
            {
                var contact = _contactRepository.GetById(id);

                if (contact != null)
                {
                    contacts.Add(contact);
                }

            }

            var oldCount = _contactRepository.GetCount();

            if (contacts.Count == 0)
            {
                return new
                {
                    Success = false,
                    ErrorCode = ServerError.ALL_CONTACTS_NOT_FOUND,
                    DeleteCount = 0,
                    Message = "Контакты не найдены!"
                };
            }

            _contactRepository.Delete(contacts);
            _contactRepository.Save();

            var newCount = _contactRepository.GetCount();

            return new { Success = true, DeleteCount = oldCount - newCount };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}