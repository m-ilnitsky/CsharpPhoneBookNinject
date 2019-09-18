using System.Collections.Generic;
using System.Linq;
using CsharpPhoneBookEF.Model.Dtos;
using CsharpPhoneBookEF.Model.Entities;

namespace CsharpPhoneBookEF.Model.BusinessLogic
{
    public static class MappingExpressions
    {
        public static Contact ToModel(this ContactDto dto)
        {
            return new Contact
            {
                Id = dto.Id,
                Name = dto.Name,
                Family = dto.Family,
                Phone = PhoneFormatting.SimplifyPhone(dto.Phone)
            };
        }

        public static ContactDto ToDto(this Contact c)
        {
            return new ContactDto
            {
                Id = c.Id,
                Name = c.Name,
                Family = c.Family,
                Phone = PhoneFormatting.FormatPhone(c.Phone)
            };
        }

        public static List<ContactDto> ToDto(this List<Contact> contactList)
        {
            return contactList.Select(c => ToDto(c)).ToList();
        }
    }
}