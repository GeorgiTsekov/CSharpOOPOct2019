
using P03WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P03WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double increaseWeight = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override List<Type> PrefferedFoodTypes => new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => increaseWeight;

        public override string AskFood()
        {
            return "Hoot Hoot";
        }
    }
}
