
using P03WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P03WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double increaseWeight = 1.00;
        public Tiger(string name, double weight, string livingRegion, string bread) 
            : base(name, weight, livingRegion, bread)
        {
        }

        protected override List<Type> PrefferedFoodTypes => new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => increaseWeight;

        public override string AskFood()
        {
            return "ROAR!!!";
        }
    }
}
