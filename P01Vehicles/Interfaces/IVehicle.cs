namespace P01Vehicles.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }

        string Drive(double distance);
        void Refuel(double liters);
        string DriveEmpty(double distance);
    }
}
