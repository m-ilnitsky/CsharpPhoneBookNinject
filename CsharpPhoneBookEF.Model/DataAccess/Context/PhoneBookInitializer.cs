using System.Data.Entity;

using CsharpPhoneBookEF.Model.Entities;

namespace CsharpPhoneBookEF.Model.Context
{
    public class PhoneBookInitializer
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
                    Name = "",
                    Family = "Атыбаев",
                    Phone = "+37444555666"
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
                    Phone = "127127"
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
                    Family = "Попов",
                    Phone = "335578"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Вавилова",
                    Phone = "333333"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Запилова",
                    Phone = "254431"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Гладков",
                    Phone = "22445"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Французов",
                    Phone = "22744"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Царёв",
                    Phone = "32244"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Василич",
                    Family = "",
                    Phone = "3332244"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Петрович",
                    Family = "",
                    Phone = "3331555"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Палыч",
                    Family = "",
                    Phone = "3777555"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Михалыч",
                    Family = "",
                    Phone = "7775553"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Саныч",
                    Family = "",
                    Phone = "2244888"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Моисеич",
                    Family = "",
                    Phone = "3322255"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Филиппыч",
                    Family = "",
                    Phone = "7777777"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Иммануилыч",
                    Family = "",
                    Phone = "7777771"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Костяныч",
                    Family = "",
                    Phone = "7777722"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Борисыч",
                    Family = "",
                    Phone = "7777333"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Юрич",
                    Family = "",
                    Phone = "7774444"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Романыч",
                    Family = "",
                    Phone = "7755555"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "Иваныч",
                    Family = "",
                    Phone = "7666666"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Неизвестные",
                    Phone = "8888881"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Неизвестные",
                    Phone = "8888818"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Неизвестные",
                    Phone = "8888188"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Неизвестные",
                    Phone = "8881888"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Неизвестные",
                    Phone = "8818888"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Неизвестные",
                    Phone = "8188888"
                });
                phoneBook.Contacts.Add(new Contact
                {
                    Name = "",
                    Family = "Неизвестные",
                    Phone = "1888888"
                });

                phoneBook.SaveChanges();
            }
        }
    }
}
