using System.Collections.Generic;
using System.Web.Http;

using CsharpPhoneBookEF.Model.Dtos;
using CsharpPhoneBookEF.Model.Handlers;

namespace CsharpPhoneBookEF.Controllers
{
    public class PhoneBookController : ApiController
    {
        // GET: api/PhoneBook/getContacts? term = +7913
        public List<ContactDto> GetContacts(string term)
        {
            return PhoneBookHandler.GetContacts(term);
        }

        [HttpPost]
        public BaseResponse AddContact(ContactDto contactDto)
        {
            return PhoneBookHandler.AddContact(contactDto);
        }

        [HttpPost]
        public BaseResponse EditContact(ContactDto contactDto)
        {
            return PhoneBookHandler.EditContact(contactDto);
        }

        [HttpPost]
        public BaseResponse DeleteContact([FromBody]int id)
        {
            return PhoneBookHandler.DeleteContact(id);
        }

        [HttpPost]
        public BaseResponse DeleteContacts(List<int> ids)
        {
            return PhoneBookHandler.DeleteContacts(ids);
        }
    }
}