namespace P05BorderControl.Core
{
    using P05BorderControl.Creatures;
    using System;

    public class Engine
    {
        private Creature creature;

        public Engine()
        {
            this.creature = new Creature();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splitedInput = input.Split();

                if (splitedInput[0] == "Robot")
                {
                    string robotModel = splitedInput[1];
                    string robotId = splitedInput[2];

                    Robot robot = new Robot(robotModel, robotId);
                    creature.AddId(robotId);
                }
                else if (splitedInput[0] == "Citizen")
                {
                    string citizenName = splitedInput[1];
                    int citizenAge = int.Parse(splitedInput[2]);
                    string citizenId = splitedInput[3];
                    string citizenDate = splitedInput[4];

                    Citizen citizen = new Citizen(citizenName, citizenAge, citizenId, citizenDate);
                    creature.AddDate(citizenDate);
                }
                else if (splitedInput[0] == "Pet")
                {
                    string petName = splitedInput[1];
                    string petDate = splitedInput[2];

                    Pet pet = new Pet(petName, petDate);
                    creature.AddDate(petDate);
                }
            }

            string lastDigits = Console.ReadLine();

            Console.WriteLine(creature.ISLastDigitsOfDate(lastDigits));
        }
    }
}
