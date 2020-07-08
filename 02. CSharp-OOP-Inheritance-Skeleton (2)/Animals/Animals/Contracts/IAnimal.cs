namespace Animals.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        int Age { get; }
        string Gender { get; }
        string ProduceSound();
        string Print();
    }
}
