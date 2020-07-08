
namespace P04Telephony.SmartPhones
{
    using System;
    using P04Telephony.Contracts;
    using System.Linq;
    using Exceptions;

    public class Smartphone : IBrowse, ICall
    {
        public Smartphone()
        {
        }

        public string Browse(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMesseges.InvalidURL);
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(c => char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMesseges.InvalidNumber);
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
