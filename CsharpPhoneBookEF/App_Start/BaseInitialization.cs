using System.Data.Entity;
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
                    Phone = "+78123334455"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Кецалькоатль",
                    Family = "",
                    Phone = "+78008008888"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Ленин",
                    Family = "",
                    Phone = "911"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Сталин",
                    Family = "",
                    Phone = "1122"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Васечкин",
                    Phone = "3335577"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Петечкин",
                    Phone = "333555"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Атыбаев",
                    Phone = "+37444555666"
                });

                phoneBook.SaveChanges();
            }
        }
    }
}