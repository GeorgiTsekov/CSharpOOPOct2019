using MXGP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;

        public Engine()
        {
            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = inputInfo[0];

                if (command == "End")
                {
                    break;
                }

                try
                {
                    if (command == "CreateRider")
                    {
                        string name = inputInfo[1];

                        Console.WriteLine(this.championshipController.CreateRider(name));
                    }
                    else if (command == "CreateMotorcycle")
                    {
                        string type = inputInfo[1];
                        string model = inputInfo[2];
                        int horsePower = int.Parse(inputInfo[3]);

                        Console.WriteLine(this.championshipController.CreateMotorcycle(type, model, horsePower));
                    }
                    else if (command == "AddMotorcycleToRider")
                    {
                        string riderName = inputInfo[1];
                        string motorcycleModel = inputInfo[2];

                        Console.WriteLine(this.championshipController.AddMotorcycleToRider(riderName, motorcycleModel));
                    }
                    else if (command == "AddRiderToRace")
                    {
                        string raceName = inputInfo[1];
                        string riderName = inputInfo[2];

                        Console.WriteLine(this.championshipController.AddRiderToRace(raceName, riderName));
                    }
                    else if (command == "CreateRace")
                    {
                        string name = inputInfo[1];
                        int laps = int.Parse(inputInfo[2]);

                        Console.WriteLine(this.championshipController.CreateRace(name, laps));
                    }
                    else if (command == "StartRace")
                    {
                        string raceName = inputInfo[1];

                        Console.WriteLine(this.championshipController.StartRace(raceName));
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }
    }
}
