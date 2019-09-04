using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CsharpPhoneBookEF.Models;

namespace CsharpPhoneBookEF.App_Start
{
    public class BaseInitialization
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PhoneBookContext>());

            using (var phoneBook = new PhoneBookContext())
            {
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Иван",
                    Family = "Иванов",
                    Phone = "+79138131122"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Василий",
                    Family = "Васильев",
                    Phone = "+79339339933"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Константин",
                    Family = "Константинов",
                    Phone = "+74953334455"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Юрий",
                    Family = "Юрьев",
                    Phone = "+7812223344"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Кецалькоатль",
                    Phone = "88008008888"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Ленин",
                    Phone = "911"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Сталин",
                    Phone = "112"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Family = "Васечкин",
                    Phone = "3335501"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Family = "Петечкин",
                    Phone = "3335502"
                });

                phoneBook.SaveChanges();
            }
        }
    }
}