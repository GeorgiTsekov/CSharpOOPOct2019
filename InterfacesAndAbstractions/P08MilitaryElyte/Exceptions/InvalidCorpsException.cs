
namespace P08MilitaryElyte.Exceptions
{
    using System;
    public class InvalidCorpsException : Exception
    {
        private const string EXC_MESSEGE = "Invalid corps!";
        public InvalidCorpsException()
            : base(EXC_MESSEGE)
        {

        }

        public InvalidCorpsException(string message)
            : base(message)
        {
        }
    }
}
