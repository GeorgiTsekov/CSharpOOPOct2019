namespace P01Vehicles.Models
{
    using P01Vehicles.Exceptions;
    using P01Vehicles.Interfaces;
    using System;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            double travelledDistance = distance * this.FuelConsumption;

            string vehicleType = this.GetType().Name;

            if (travelledDistance <= this.FuelQuantity)
            {
                this.FuelQuantity -= travelledDistance;

                return $"{vehicleType} travelled {distance} km";
            }
            else
            {
                return $"{vehicleType} needs refueling";
            }
        }

        public virtual string DriveEmpty(double distance)
        {
            return this.Drive(distance);
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(ExceptionMesseges.NegativeFuelExeption);
            }
            else
            {
                double momentCapacity = liters + this.FuelQuantity;

                if (this.TankCapacity < momentCapacity)
                {
                    throw new ArgumentException(String.Format(ExceptionMesseges.FullTankException, liters));
                }
                else
                {
                    this.FuelQuantity += liters;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
