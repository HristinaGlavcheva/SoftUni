using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string DefaultExceptionMessage = "Invalid corps!";

        public InvalidCorpsException()
            : base(DefaultExceptionMessage)
        {
        }

        public InvalidCorpsException(string message) 
            : base(message)
        {
        }
    }
}
