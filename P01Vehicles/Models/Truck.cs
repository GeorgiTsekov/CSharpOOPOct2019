namespace P01Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double airConditionConsumption = 1.6;
        private const double weistedFuel = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + airConditionConsumption;

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity -= liters * weistedFuel;
        }
    }
}
