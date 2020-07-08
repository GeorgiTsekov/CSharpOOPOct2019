using P03WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double increaseWeight = 0.30;
        public Cat(string name, double weight, string livingRegion, string bread)
            : base(name, weight, livingRegion, bread)
        {
        }

        protected override List<Type> PrefferedFoodTypes => new List<Type> { typeof(Vegetable), typeof(Meat) };

        protected override double WeightMultiplier => increaseWeight;

        public override string AskFood()
        {
            return "Meow";
        }
    }
}
