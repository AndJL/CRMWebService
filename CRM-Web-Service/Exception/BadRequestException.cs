namespace CRM_Web_Service.Exception
{
    public class BadRequestException : System.Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}