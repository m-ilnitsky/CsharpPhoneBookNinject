using System.Collections.Generic;

using CsharpPhoneBookEF.Model.BusinessLogic;
using CsharpPhoneBookEF.Model.Dtos;
using CsharpPhoneBookEF.Model.Entities;
using CsharpPhoneBookEF.Model.Repositories;
using CsharpPhoneBookEF.Model.Context;

namespace CsharpPhoneBookEF.Model.Handlers
{
    public class PhoneBookHandler
    {
        public static List<ContactDto> GetContacts(string term)
        {
            using (var uow = new UnitOfWork(new PhoneBookContext()))
            {
                var contactRepository = (ContactRepository)uow.GetRepository<IContactRepository>();

                if (string.IsNullOrEmpty(term))
                {
                    return contactRepository.GetAll().ToDto();
                }

                return contactRepository.GetAllWithString(term).ToDto();
            }
        }

        public static HttpResponse AddContact(ContactDto contactDto)
        {
            using (var uow = new UnitOfWork(new PhoneBookContext()))
            {
                var contactRepository = (ContactRepository)uow.GetRepository<IContactRepository>();

                if (contactRepository.PhoneExists(contactDto.Phone))
                {
                    return new HttpResponse
                    {
                        Success = false,
                        ErrorCode = ServerError.IsPhoneNumber,
                        Message = "Такой номер уже имеется на сервере"
                    };
                }

                contactRepository.Create(contactDto.ToModel());
                contactRepository.Save();

                return new HttpResponse { Success = true };
            }
        }

        public static HttpResponse EditContact(ContactDto contactDto)
        {
            using (var uow = new UnitOfWork(new PhoneBookContext()))
            {
                var contactRepository = (ContactRepository)uow.GetRepository<IContactRepository>();

                Contact contact = contactRepository.GetById(contactDto.Id);

                if (contact == null)
                {
                    return new HttpResponse
                    {
                        Success = false,
                        ErrorCode = ServerError.ContactNotFound,
                        Message = "Контакт не найден!"
                    };
                }

                var changedContact = contactDto.ToModel();

                contact.Name = changedContact.Name;
                contact.Family = changedContact.Family;
                contact.Phone = changedContact.Phone;

                contactRepository.Update(contact);
                contactRepository.Save();

                return new HttpResponse { Success = true };
            }
        }

        public static HttpResponse DeleteContact(int id)
        {
            using (var uow = new UnitOfWork(new PhoneBookContext()))
            {
                var contactRepository = (ContactRepository)uow.GetRepository<IContactRepository>();

                Contact contact = contactRepository.GetById(id);

                if (contact == null)
                {
                    return new HttpResponse
                    {
                        Success = false,
                        ErrorCode = ServerError.ContactNotFound,
                        Message = "Контакт не найден!"
                    };
                }

                contactRepository.Delete(contact);
                contactRepository.Save();

                return new HttpResponse { Success = true };
            }
        }

        public static HttpResponse DeleteContacts(List<int> ids)
        {
            using (var uow = new UnitOfWork(new PhoneBookContext()))
            {
                var contactRepository = (ContactRepository)uow.GetRepository<IContactRepository>();

                var contacts = new List<Contact>();

                foreach (var id in ids)
                {
                    var contact = contactRepository.GetById(id);

                    if (contact != null)
                    {
                        contacts.Add(contact);
                    }

                }

                var oldCount = contactRepository.GetCount();

                if (contacts.Count == 0)
                {
                    return new HttpResponse
                    {
                        Success = false,
                        ErrorCode = ServerError.AllContactsNotFound,
                        DeleteCount = 0,
                        Message = "Контакты не найдены!"
                    };
                }

                contactRepository.Delete(contacts);
                contactRepository.Save();

                var newCount = contactRepository.GetCount();

                return new HttpResponse { Success = true, DeleteCount = oldCount - newCount };
            }
        }
    }
}
