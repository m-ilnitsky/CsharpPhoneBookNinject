using System.Collections.Generic;

using CsharpPhoneBookEF.Model.Dtos;

namespace CsharpPhoneBookEF.Model.Handlers
{
    public interface IPhoneBookHandler
    {
        List<ContactDto> GetContacts(string term);

        BaseResponse AddContact(ContactDto contactDto);

        BaseResponse EditContact(ContactDto contactDto);

        BaseResponse DeleteContact(int id);

        BaseResponse DeleteContacts(List<int> ids);
    }
}
