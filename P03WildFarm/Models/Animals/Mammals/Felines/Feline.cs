
namespace P03WildFarm.Models.Animals.Mammals.Felines
{
    using P03WildFarm.Contracts;

    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weight, string livingRegion, string bread) 
            : base(name, weight, livingRegion)
        {
            this.Breed = bread;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
