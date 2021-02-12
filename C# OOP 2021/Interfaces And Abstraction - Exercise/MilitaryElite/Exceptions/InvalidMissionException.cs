using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionException : Exception
    {
        private const string DefaultExceptionMessage = "Invalid mission state!";

        public InvalidMissionException()
            : base(DefaultExceptionMessage)
        {
        }

        public InvalidMissionException(string message)
            : base(message)
        {
        }
    }
}
