
namespace P08MilitaryElyte.Exceptions
{
    using System;

    public class InvalidMissionCompletionException : Exception
    {
        private const string EXC_MESSEGE = "You cannot finish already completed mission!";

        public InvalidMissionCompletionException()
            : base (EXC_MESSEGE)
        {

        }

        public InvalidMissionCompletionException(string message) 
            : base(message)
        {

        }
    }
}
