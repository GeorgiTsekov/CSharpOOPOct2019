namespace Animals.Core
{
    using System;
    using System.Collections.Generic;
    using Animals;
    using Animals.Cats;
    using Animals.Dogs;
    using Animals.Frogs;

    public class Engine
    {
        private List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                try
                {
                    string classType = input;

                    string[] animalArgs = Console.ReadLine()
                        .Split();

                    if (animalArgs.Length != 3)
                    {
                        throw new ArgumentException(Exceptions.ExceptionMessages.InvalidInputMessage);
                    }
                    else
                    {
                        string name = animalArgs[0];
                        int age = int.Parse(animalArgs[1]);
                        string gender = animalArgs[2];

                        if (classType == "Kitten")
                        {
                            Animal kitten = new Kitten(name, age, gender);
                            animals.Add(kitten);
                        }
                        else if (classType == "Tomcat")
                        {
                            Animal tomcat = new Tomcat(name, age, gender);
                            animals.Add(tomcat);
                        }
                        else if (classType == "Dog")
                        {
                            Animal dog = new Dog(name, age, gender);
                            animals.Add(dog);
                        }
                        else if (classType == "Cat")
                        {
                            Animal cat = new Cat(name, age, gender);
                            animals.Add(cat);
                        }
                        else if (classType == "Frog")
                        {
                            Animal frog = new Frog(name, age, gender);
                            animals.Add(frog);
                        }
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Print());
            }
        }
    }
}
