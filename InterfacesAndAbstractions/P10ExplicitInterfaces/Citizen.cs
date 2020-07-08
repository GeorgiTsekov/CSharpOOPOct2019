using P10ExplicitInterfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P10ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name,string country , int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual string Name { get; private set; }

        public int Age { get; private set; }

        string IResident.Name { get; }

        string IResident.Country { get; }

        public virtual string GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return "Mr/Ms/Mrs " + this.Name;
        }
    }
}
