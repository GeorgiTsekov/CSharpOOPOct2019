
namespace P03WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string AskFood();
        void Feed(IFood food);
    }
}
