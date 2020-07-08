namespace MXGP.Models.Motorcycles
{
    using MXGP.Utilities.Messages;
    using System;

    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;
        private const double CubicCentimetersConst = 450;
        private const int MinHorsePower = 70;
        private const int MaxHorsePower = 100;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CubicCentimetersConst)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value > MaxHorsePower || value < MinHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
