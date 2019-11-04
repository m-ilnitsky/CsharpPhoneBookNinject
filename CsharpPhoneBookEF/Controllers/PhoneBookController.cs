using System.Collections.Generic;
using System.Web.Http;
using System;

using CsharpPhoneBookEF.Model.Dtos;
using CsharpPhoneBookEF.Model.Handlers;

namespace CsharpPhoneBookEF.Controllers
{
    public class PhoneBookController : ApiController
    {
        private readonly IPhoneBookHandler _phoneBookHandler;

        public PhoneBookController(IPhoneBookHandler phoneBookHandler)
        {
            _phoneBookHandler = phoneBookHandler ?? throw new ArgumentNullException(nameof(phoneBookHandler));
        }

        // GET: api/PhoneBook/getContacts? term = +7913
        public List<ContactDto> GetContacts(string term)
        {
            return _phoneBookHandler.GetContacts(term);
        }

        [HttpPost]
        public BaseResponse AddContact(ContactDto contactDto)
        {
            return _phoneBookHandler.AddContact(contactDto);
        }

        [HttpPost]
        public BaseResponse EditContact(ContactDto contactDto)
        {
            return _phoneBookHandler.EditContact(contactDto);
        }

        [HttpPost]
        public BaseResponse DeleteContact([FromBody]int id)
        {
            return _phoneBookHandler.DeleteContact(id);
        }

        [HttpPost]
        public BaseResponse DeleteContacts(List<int> ids)
        {
            return _phoneBookHandler.DeleteContacts(ids);
        }
    }
}