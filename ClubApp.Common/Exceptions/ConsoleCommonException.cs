using System;
using Microsoft.AspNetCore.Http;

namespace ClubApp.Common.Exceptions
{
    public class ConsoleCommonException: ConsoleExceptionBase
    {
        public ConsoleCommonException() : base(StatusCodes.Status500InternalServerError) { }

        public ConsoleCommonException(string message) : base(StatusCodes.Status500InternalServerError, message) { }

    }
}
