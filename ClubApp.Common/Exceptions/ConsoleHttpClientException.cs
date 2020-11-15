namespace ClubApp.Common.Exceptions
{
    public class ConsoleHttpClientException : ConsoleExceptionBase
    {
        public ConsoleHttpClientException(int statusCode, string message) : base(statusCode, message) { }
    }
}
