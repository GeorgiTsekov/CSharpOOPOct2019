namespace Animals.Animals.Cats
{
    public class Kitten : Animal
    {
        private const string sound = "Meow";

        public Kitten(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string Gender => "Female";

        public override string ProduceSound()
        {
            return sound;
        }
    }
}
