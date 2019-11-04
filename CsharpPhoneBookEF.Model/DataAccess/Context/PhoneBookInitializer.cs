using CsharpPhoneBookEF.Model.Entities;
using CsharpPhoneBookEF.Model.Repositories;

namespace CsharpPhoneBookEF.Model.Context
{
    public class PhoneBookInitializer
    {
        public static void Initialize()
        {
            using (var uow = new UnitOfWork(new PhoneBookContext()))
            {
                var contactRepository = uow.GetRepository<IContactRepository>();

                if (contactRepository.GetCount() == 0)
                {
                    contactRepository.Create(new Contact
                    {
                        Name = "Иван",
                        Family = "Иванов",
                        Phone = "+79138131122"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Василий",
                        Family = "Васильев",
                        Phone = "+79339339933"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Константин",
                        Family = "Константинов",
                        Phone = "+74953334455"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Юрий",
                        Family = "Юрьев",
                        Phone = "+78123334455"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Кецалькоатль",
                        Family = "",
                        Phone = "+78008008888"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Атыбаев",
                        Phone = "+37444555666"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Ленин",
                        Family = "",
                        Phone = "911"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Сталин",
                        Family = "",
                        Phone = "1122"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Васечкин",
                        Phone = "127127"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Петечкин",
                        Phone = "333555"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Попов",
                        Phone = "335578"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Вавилова",
                        Phone = "333333"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Запилова",
                        Phone = "254431"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Гладков",
                        Phone = "22445"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Французов",
                        Phone = "22744"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Царёв",
                        Phone = "32244"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Василич",
                        Family = "",
                        Phone = "3332244"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Петрович",
                        Family = "",
                        Phone = "3331555"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Палыч",
                        Family = "",
                        Phone = "3777555"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Михалыч",
                        Family = "",
                        Phone = "7775553"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Саныч",
                        Family = "",
                        Phone = "2244888"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Моисеич",
                        Family = "",
                        Phone = "3322255"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Филиппыч",
                        Family = "",
                        Phone = "7777777"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Иммануилыч",
                        Family = "",
                        Phone = "7777771"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Костяныч",
                        Family = "",
                        Phone = "7777722"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Борисыч",
                        Family = "",
                        Phone = "7777333"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Юрич",
                        Family = "",
                        Phone = "7774444"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Романыч",
                        Family = "",
                        Phone = "7755555"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "Иваныч",
                        Family = "",
                        Phone = "7666666"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Неизвестные",
                        Phone = "8888881"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Неизвестные",
                        Phone = "8888818"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Неизвестные",
                        Phone = "8888188"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Неизвестные",
                        Phone = "8881888"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Неизвестные",
                        Phone = "8818888"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Неизвестные",
                        Phone = "8188888"
                    });
                    contactRepository.Create(new Contact
                    {
                        Name = "",
                        Family = "Неизвестные",
                        Phone = "1888888"
                    });

                    uow.Save();
                }
            }
        }
    }
}
