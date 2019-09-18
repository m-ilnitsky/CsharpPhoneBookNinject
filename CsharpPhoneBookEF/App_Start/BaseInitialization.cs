using CsharpPhoneBookEF.Model.Context;

namespace CsharpPhoneBookEF.App_Start
{
    public class BaseInitialization
    {
        public static void Initialize()
        {
            PhoneBookInitializer.Initialize();
        }
    }
}