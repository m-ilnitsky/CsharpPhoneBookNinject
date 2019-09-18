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
        public HttpResponse AddContact([FromBody]ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return GetResponseModelIsInvalid();
            }

            return PhoneBookHandler.AddContact(contactDto);
        }

        [HttpPost]
        public HttpResponse EditContact([FromBody]ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return GetResponseModelIsInvalid();
            }

            return PhoneBookHandler.EditContact(contactDto);
        }

        [HttpPost]
        public HttpResponse DeleteContact([FromBody]int id)
        {
            if (!ModelState.IsValid)
            {
                return GetResponseModelIsInvalid();
            }

            return PhoneBookHandler.DeleteContact(id);
        }

        [HttpPost]
        public HttpResponse DeleteContacts([FromBody]List<int> ids)
        {
            if (!ModelState.IsValid)
            {
                return GetResponseModelIsInvalid();
            }

            return PhoneBookHandler.DeleteContacts(ids);
        }

        private HttpResponse GetResponseModelIsInvalid()
        {
            return new HttpResponse
            {
                Success = false,
                ErrorCode = ServerError.ModelStateIsInvalid,
                DeleteCount = 0,
                Message = "Неполадки на сервере!"
            };
        }
    }
}