
namespace P03Ferrari.Cars
{
    using P03Ferrari.Contracts;
    using System;
    public class Ferrari : IDriver
    {
        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
            this.Model = "488-Spider";
        }

        public string DriverName { get; private set; }

        public string Model { get; private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.DriverName}";
        }
    }
}
