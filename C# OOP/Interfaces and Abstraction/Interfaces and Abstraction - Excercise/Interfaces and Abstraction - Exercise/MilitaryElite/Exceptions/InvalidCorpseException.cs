using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidCorpseException : Exception
    {
        private const string DEF_EX_MSG = "Invalid corps!";
        
        public InvalidCorpseException()
            :base(DEF_EX_MSG)
        {

        }

        public InvalidCorpseException(string message)
            : base(message)
        {

        }
    }
}
