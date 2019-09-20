namespace CsharpPhoneBookEF.Model.Dtos
{
    public enum ServerError
    {
        AllRight = 0,
        IsPhoneNumber = 1,
        ContactNotFound = 11,
        AllContactsNotFound = 21,
        ModelStateIsInvalid = 31
    }
}