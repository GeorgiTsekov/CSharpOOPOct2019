using P10ExplicitInterfaces.Contracts;
using System;

namespace P10ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenArgs = input.Split(" ");

                string name = citizenArgs[0];
                string country = citizenArgs[1];
                int age = int.Parse(citizenArgs[2]);

                Citizen citizen = new Citizen(name, country, age);

                IResident resident = citizen;

                Console.WriteLine(citizen.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
