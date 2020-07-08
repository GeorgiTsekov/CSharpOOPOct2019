namespace P05BorderControl.Creatures
{
    using P05BorderControl.Contracts;

    public class Citizen : IIdNumber, IBirthDate
    {
        public Citizen(string name, int age, string idNumber, string birthDate)
        {
            this.IdNumber = idNumber;
            this.Name = name;
            this.Age = age;
            this.BirthDate = birthDate;
        }

        public string IdNumber { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string BirthDate { get; private set; }
    }
}
