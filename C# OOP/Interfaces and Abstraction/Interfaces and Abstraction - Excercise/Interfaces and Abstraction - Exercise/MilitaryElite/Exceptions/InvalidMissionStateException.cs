using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionStateException : Exception
    {
        private const string DEF_EX_MSG = "Invalid mission state!";
        
        public InvalidMissionStateException()
            :base(DEF_EX_MSG)
        {

        }

        public InvalidMissionStateException(string message) 
            : base(message)
        {

        }
    }
}
