
namespace P03WildFarm.Models.Animals.Birds
{
    using P03WildFarm.Models.Foods;
    using System;
    using System.Collections.Generic;

    public class Hen : Bird
    {
        private const double increaseWeight = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override List<Type> PrefferedFoodTypes => new List<Type> { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        protected override double WeightMultiplier => increaseWeight;

        public override string AskFood()
        {
            return "Cluck";
        }
    }
}
