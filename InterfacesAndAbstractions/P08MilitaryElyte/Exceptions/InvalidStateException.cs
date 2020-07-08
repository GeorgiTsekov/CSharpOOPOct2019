using System;
namespace P08MilitaryElyte.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string EXC_MESSAGE = "Invalid mission state!";
        public InvalidStateException()
            : base(EXC_MESSAGE)
        {

        }

        public InvalidStateException(string message) 
            : base(message)
        {

        }
    }
}
