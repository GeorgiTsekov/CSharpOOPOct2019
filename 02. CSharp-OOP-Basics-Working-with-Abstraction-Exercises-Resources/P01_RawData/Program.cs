namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RawData
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking();

            int countOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCars; i++)
            {
                string[] carParameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                parking.AddCars(carParameters);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = parking.GetCars()
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(t => t.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = parking.GetCars()
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
