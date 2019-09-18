namespace CsharpPhoneBookEF.Model.Handlers
{
    public class HttpResponse
    {
        public bool Success { get; set; }

        public ServerError ErrorCode { get; set; }

        public string Message { get; set; }

        public int DeleteCount { get; set; }
    }
}
