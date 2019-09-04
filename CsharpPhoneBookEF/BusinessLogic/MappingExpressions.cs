using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CsharpPhoneBookEF.Contracts;
using CsharpPhoneBookEF.Models;

namespace CsharpPhoneBookEF.BusinessLogic
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
                Phone = dto.Phone
            };
        }

        public static ContactDto ToDto(this Contact c)
        {
            return new ContactDto
            {
                Id = c.Id,
                Name = c.Name,
                Family = c.Family,
                Phone = c.Phone
            };
        }
    }
}