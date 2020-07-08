using P03Ferrari.Cars;
using P03Ferrari.Contracts;
using System;

namespace P03Ferrari
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string driverName = Console.ReadLine();

            IDriver driver = new Ferrari(driverName);

            Console.WriteLine(driver);
        }
    }
}
