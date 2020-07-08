namespace P03WildFarm.Models.Animals.Mammals
{
    using P03WildFarm.Models.Foods;
    using System;
    using System.Collections.Generic;

    public class Mouse : Mammal
    {
        private const double increaseWeight = 0.10;

        private HashSet<string> foods;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.foods = new HashSet<string>();
        }

        protected override List<Type> PrefferedFoodTypes => new List<Type> { typeof(Vegetable), typeof(Fruit) };

        protected override double WeightMultiplier => increaseWeight;

        public override string AskFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{ this.Weight}, { this.LivingRegion}, { this.FoodEaten}]";
        }
    }
}
