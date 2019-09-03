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
        public static Expression<Func<Contact, ContactDto>> MapContact
        {
            get
            {
                return e => new ContactDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Family = e.Family,
                    Phone = e.Phone
                };
            }
        }
    }
}