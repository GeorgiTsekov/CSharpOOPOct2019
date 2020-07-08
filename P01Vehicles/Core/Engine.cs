namespace P01Vehicles.Core
{
    using P01Vehicles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly Dictionary<string, Vehicle> vehicles;

        public Engine()
        {
            this.vehicles = new Dictionary<string, Vehicle>();
        }

        public void Run()
        {
            string[] carData = Console.ReadLine()
            .Split(" ");

            double carFuelQuantity = double.Parse(carData[1]);
            double carFuelConsumption = double.Parse(carData[2]);
            double carFuelTank = double.Parse(carData[3]);

            Vehicle car = new Car(carFuelQuantity, carFuelConsumption, carFuelTank);
            vehicles.Add(carData[0], car);

            string[] truckData = Console.ReadLine()
                .Split(" ");

            double truckFuelQuantity = double.Parse(truckData[1]);
            double truckFuelConsumption = double.Parse(truckData[2]);
            double truckFuelTank = double.Parse(truckData[3]);

            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckFuelTank);
            vehicles.Add(truckData[0], truck);

            string[] busData = Console.ReadLine()
                .Split(" ");

            double busFuelQuantity = double.Parse(busData[1]);
            double busFuelConsumption = double.Parse(busData[2]);
            double busFuelTank = double.Parse(busData[3]);

            Vehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busFuelTank);
            vehicles.Add(busData[0], bus);

            int countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ");

                switch (command[0])
                {
                    case "Drive":
                        string vehicleType = command[1];
                        double distance = double.Parse(command[2]);

                        Vehicle vehicle = vehicles.Where(x => x.Key == vehicleType).FirstOrDefault().Value;

                        Console.WriteLine(vehicle.Drive(distance));

                        break;
                    case "Refuel":
                        try
                        {
                            vehicleType = command[1];
                            double litres = double.Parse(command[2]);

                            vehicle = vehicles.Where(x => x.Key == vehicleType).FirstOrDefault().Value;

                            vehicle.Refuel(litres);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }


                        break;
                    case "DriveEmpty":
                        vehicleType = command[1];
                        distance = double.Parse(command[2]);

                        vehicle = vehicles.Where(x => x.Key == vehicleType).FirstOrDefault().Value;

                        Console.WriteLine(vehicle.DriveEmpty(distance));

                        break;
                    default:
                        break;
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Value);
            }
        }
    }
}
