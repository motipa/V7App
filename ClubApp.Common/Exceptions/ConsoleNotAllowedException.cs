using Microsoft.AspNetCore.Http;

namespace ClubApp.Common.Exceptions
{
    public class ConsoleNotAllowedException : ConsoleExceptionBase
    {
        public ConsoleNotAllowedException() : base(StatusCodes.Status405MethodNotAllowed) { }
       
        public ConsoleNotAllowedException(string message) : base(StatusCodes.Status405MethodNotAllowed, message) { }
    }
}
