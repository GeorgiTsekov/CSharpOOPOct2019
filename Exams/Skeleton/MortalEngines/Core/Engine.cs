namespace MortalEngines.Core
{
    using MortalEngines.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IMachinesManager machinesManager;
        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            while (true)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandArgs[0];

                if (command == "Quit")
                {
                    break;
                }

                try
                {
                    switch (command)
                    {
                        case "HirePilot":
                            string pilotName = commandArgs[1];
                            Console.WriteLine(this.machinesManager.HirePilot(pilotName));
                            break;
                        case "PilotReport":
                            pilotName = commandArgs[1];
                            Console.WriteLine(this.machinesManager.PilotReport(pilotName));
                            break;
                        case "ManufactureTank":
                            string tankName = commandArgs[1];
                            double attackPoints = double.Parse(commandArgs[2]);
                            double deffencePoints = double.Parse(commandArgs[3]);
                            Console.WriteLine(this.machinesManager.ManufactureTank(tankName, attackPoints, deffencePoints));
                            break;
                        case "ManufactureFighter":
                            string fighterName = commandArgs[1];
                            attackPoints = double.Parse(commandArgs[2]);
                            deffencePoints = double.Parse(commandArgs[3]);
                            Console.WriteLine(this.machinesManager.ManufactureFighter(fighterName, attackPoints, deffencePoints));
                            break;
                        case "MachineReport":
                            string machineName = commandArgs[1];
                            Console.WriteLine(this.machinesManager.MachineReport(machineName));
                            break;
                        case "AggressiveMode":
                            fighterName = commandArgs[1];
                            Console.WriteLine(this.machinesManager.ToggleFighterAggressiveMode(fighterName));
                            break;
                        case "DefenseMode":
                            tankName = commandArgs[1];
                            Console.WriteLine(this.machinesManager.ToggleTankDefenseMode(tankName));
                            break;
                        case "Engage":
                            pilotName = commandArgs[1];
                            tankName = commandArgs[2];
                            Console.WriteLine(this.machinesManager.EngageMachine(pilotName, tankName));
                            break;
                        case "Attack":
                            string attackingMachineName = commandArgs[1];
                            string deffendingingMachineName = commandArgs[2];
                            Console.WriteLine(this.machinesManager.AttackMachines(attackingMachineName, deffendingingMachineName));
                            break;
                        default:
                            break;
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
