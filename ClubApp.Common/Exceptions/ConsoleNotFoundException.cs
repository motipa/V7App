using Microsoft.AspNetCore.Http;

namespace ClubApp.Common.Exceptions
{
    public class ConsoleNotFoundException : ConsoleExceptionBase
    {
        public ConsoleNotFoundException() : base(StatusCodes.Status404NotFound) { }

        public ConsoleNotFoundException(string message) : base(StatusCodes.Status404NotFound, message) { }
    }
}
