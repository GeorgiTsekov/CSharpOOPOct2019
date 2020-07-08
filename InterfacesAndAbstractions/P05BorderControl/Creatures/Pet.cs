using P05BorderControl.Contracts;

namespace P05BorderControl.Creatures
{
    public class Pet : IBirthDate
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name { get; set; }

        public string BirthDate { get; private set; }
    }
}
