using P03WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P03WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double increaseWeight = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override List<Type> PrefferedFoodTypes => new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => increaseWeight;

        public override string AskFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{ this.Weight}, { this.LivingRegion}, { this.FoodEaten}]";
        }
    }
}
