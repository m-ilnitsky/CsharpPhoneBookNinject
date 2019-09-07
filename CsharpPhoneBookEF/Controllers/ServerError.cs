namespace CsharpPhoneBookEF.Controllers
{
    public enum ServerError
    {
        ALL_RIGHT = 0,
        IS_PHONE_NUMBER = 1,
        CONTACT_NOT_FOUND = 11,
        ALL_CONTACTS_NOT_FOUND = 21,
        MODEL_STATE_IS_INVALID = 31
    }
}