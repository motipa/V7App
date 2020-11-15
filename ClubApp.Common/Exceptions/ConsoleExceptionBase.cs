using System;

namespace ClubApp.Common.Exceptions
{
    public abstract class ConsoleExceptionBase : Exception
    {
        public readonly int StatusCode;

        public ConsoleExceptionBase(int statusCode)
        {
            StatusCode = statusCode;
        }

        public ConsoleExceptionBase(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
