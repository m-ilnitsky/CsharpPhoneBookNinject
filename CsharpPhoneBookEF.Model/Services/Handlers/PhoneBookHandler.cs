using System;
using System.Collections.Generic;

using CsharpPhoneBookEF.Model.BusinessLogic;
using CsharpPhoneBookEF.Model.Dtos;
using CsharpPhoneBookEF.Model.Entities;
using CsharpPhoneBookEF.Model.Repositories;

namespace CsharpPhoneBookEF.Model.Handlers
{
    public class PhoneBookHandler : IPhoneBookHandler, IDisposable
    {
        private readonly IUnitOfWork _uow;

        private bool _disposed;

        public PhoneBookHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _uow.Dispose();
            _disposed = true;
        }

        private void CheckDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("PhoneBookHandler: _disposed == true");
            }
        }

        public List<ContactDto> GetContacts(string term)
        {
            CheckDisposed();

            var contactRepository = _uow.GetRepository<IContactRepository>();

            if (string.IsNullOrEmpty(term))
            {
                return contactRepository.GetAll().ToDto();
            }

            return contactRepository.GetAllWithString(term).ToDto();
        }

        public BaseResponse AddContact(ContactDto contactDto)
        {
            CheckDisposed();

            var contactRepository = _uow.GetRepository<IContactRepository>();

            if (contactRepository.PhoneExists(contactDto.Phone))
            {
                return new BaseResponse
                {
                    Success = false,
                    ErrorCode = ServerError.IsPhoneNumber,
                    Message = "Такой номер уже имеется на сервере"
                };
            }

            contactRepository.Create(contactDto.ToModel());
            _uow.Save();

            return new BaseResponse { Success = true };
        }

        public BaseResponse EditContact(ContactDto contactDto)
        {
            CheckDisposed();

            var contactRepository = _uow.GetRepository<IContactRepository>();

            var contact = contactRepository.GetById(contactDto.Id);

            if (contact == null)
            {
                return new BaseResponse
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
            _uow.Save();

            return new BaseResponse { Success = true };
        }

        public BaseResponse DeleteContact(int id)
        {
            CheckDisposed();

            var contactRepository = _uow.GetRepository<IContactRepository>();

            var contact = contactRepository.GetById(id);

            if (contact == null)
            {
                return new BaseResponse
                {
                    Success = false,
                    ErrorCode = ServerError.ContactNotFound,
                    Message = "Контакт не найден!"
                };
            }

            contactRepository.Delete(contact);
            _uow.Save();

            return new BaseResponse { Success = true };
        }

        public BaseResponse DeleteContacts(List<int> ids)
        {
            CheckDisposed();

            var contactRepository = _uow.GetRepository<IContactRepository>();

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
                return new BaseResponse
                {
                    Success = false,
                    ErrorCode = ServerError.AllContactsNotFound,
                    DeleteCount = 0,
                    Message = "Контакты не найдены!"
                };
            }

            contactRepository.Delete(contacts);
            _uow.Save();

            var newCount = contactRepository.GetCount();

            return new BaseResponse { Success = true, DeleteCount = oldCount - newCount };
        }
    }
}
