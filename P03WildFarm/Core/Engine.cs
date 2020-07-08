using P03WildFarm.Contracts;
using P03WildFarm.Exceptions;
using P03WildFarm.Models.Animals;
using P03WildFarm.Models.Animals.Birds;
using P03WildFarm.Models.Animals.Mammals;
using P03WildFarm.Models.Animals.Mammals.Felines;
using P03WildFarm.Models.Foods;
using P03WildFarm.Models.Foods.Factory;
using System;
using System.Collections.Generic;

namespace P03WildFarm.Core
{
    public class Engine
    {
        private List<Animal> animals;
        private FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new List<Animal>();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                IAnimal animal = GetAnimal(input);

                string foodInput = Console.ReadLine();

                IFood food = GetFood(foodInput);

                Console.WriteLine(animal.AskFood());

                try
                {
                    animal.Feed(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private IFood GetFood(string input)
        {
            string[] foodData = input
                        .Split(" ");

            string foodType = foodData[0];
            int foodQuantity = int.Parse(foodData[1]);

            IFood food = this.foodFactory.ProduceFood(foodType, foodQuantity);

            return food;
        }

        private IAnimal GetAnimal(string input)
        {
            string[] animalData = input
                        .Split(" ");

            string animalType = animalData[0];
            string animalName = animalData[1];
            double animalWeight = double.Parse(animalData[2]);

            Animal animal;

            switch (animalType)
            {
                case "Hen":
                    double birdWingSize = double.Parse(animalData[3]);
                    animal = new Hen(animalName, animalWeight, birdWingSize);
                    break;
                case "Owl":
                    birdWingSize = double.Parse(animalData[3]);
                    animal = new Owl(animalName, animalWeight, birdWingSize);
                    break;
                case "Mouse":
                    string livingRegion = animalData[3];
                    animal = new Mouse(animalName, animalWeight, livingRegion);
                    break;
                case "Cat":
                    livingRegion = animalData[3];
                    string bread = animalData[4];
                    animal = new Cat(animalName, animalWeight, livingRegion, bread);
                    break;
                case "Dog":
                    livingRegion = animalData[3];
                    animal = new Dog(animalName, animalWeight, livingRegion);
                    break;
                case "Tiger":
                    livingRegion = animalData[3];
                    bread = animalData[4];
                    animal = new Tiger(animalName, animalWeight, livingRegion, bread);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMesseges.InvalidAnimalType);
            }

            this.animals.Add(animal);

            return animal;
        }
    }
}
