namespace Animals.Animals.Cats
{
    public class Cat : Animal
    {
        private const string sound = "Meow meow";

        public Cat(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return sound;
        }
    }
}
