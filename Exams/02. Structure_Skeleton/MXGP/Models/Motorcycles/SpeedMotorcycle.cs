namespace MXGP.Models.Motorcycles
{
    using MXGP.Utilities.Messages;
    using System;

    public class SpeedMotorcycle : Motorcycle
    {
        private int horsePower;
        private const double CubicCentimetersConst = 125;
        private const int MinHorsePower = 50;
        private const int MaxHorsePower = 69;

        public SpeedMotorcycle(string model, int horsePower) 
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
