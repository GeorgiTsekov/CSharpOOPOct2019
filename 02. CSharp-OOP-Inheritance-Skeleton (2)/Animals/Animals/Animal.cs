namespace Animals.Animals
{
    using System;
    using Contracts;
    using System.Text;

    public abstract class Animal : IAnimal
    {
        private int age;
        private string name;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                IsEmpty(value);

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Exceptions.ExceptionMessages.InvalidInputMessage);
                }
                IsEmpty(value.ToString());

                this.age = value;
            }
        }

        public virtual string Gender
        {
            get => this.gender;
            private set
            {
                IsEmpty(value);

                this.gender = value;
            }
        }

        public string Print()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(GetType().Name);
            stringBuilder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            stringBuilder.AppendLine(ProduceSound());

            return stringBuilder.ToString().TrimEnd();
        }

        public abstract string ProduceSound();

        private static void IsEmpty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(Exceptions.ExceptionMessages.InvalidInputMessage);
            }
        }
    }
}
