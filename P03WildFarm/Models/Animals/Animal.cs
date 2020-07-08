
using P03WildFarm.Contracts;
using P03WildFarm.Exceptions;
using System;
using System.Collections.Generic;

namespace P03WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public virtual double Weight { get; private set; }

        public int FoodEaten { get; private set; }

    protected abstract List<Type> PrefferedFoodTypes { get; }

        protected abstract double WeightMultiplier { get; }

        public abstract string AskFood();

        public void Feed(IFood food)
        {
            if (!this.PrefferedFoodTypes.Contains(food.GetType()))
            {
                throw new InvalidOperationException(String.Format(ExceptionMesseges.InvalidFoodException, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantity * this.WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
