namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double geodesistOxygen = 50;

        public Geodesist(string name) 
            : base(name)
        {
            this.Oxygen = geodesistOxygen;
        }
    }
}
