
namespace P04Telephony.Core
{
    using P04Telephony.SmartPhones;
    using System;

    public class Engine
    {
        private Smartphone smartphone;

        public Engine()
        {
            this.smartphone = new Smartphone();
        }

        public void Run()
        {
            string[] numbers = Console.ReadLine()
                .Split(" ");

            string[] urls = Console.ReadLine()
                .Split(" ");

            CallNumbers(numbers);
            BrowseInternet(urls);
        }

        private void CallNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Call(number));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private void BrowseInternet(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(url));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
