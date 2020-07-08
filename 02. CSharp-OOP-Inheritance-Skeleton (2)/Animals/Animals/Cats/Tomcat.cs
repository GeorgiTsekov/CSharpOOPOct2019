namespace Animals.Animals.Cats
{
    public class Tomcat : Animal
    {
        private const string sound = "MEOW";

        public Tomcat(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string Gender => "Male";

        public override string ProduceSound()
        {
            return sound;
        }
    }
}
