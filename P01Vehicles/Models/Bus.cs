namespace P01Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double airConditionConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + airConditionConsumption;

        public override string DriveEmpty(double distance)
        {
            base.FuelConsumption -= airConditionConsumption;

            return this.Drive(distance);
        }
    }
}
