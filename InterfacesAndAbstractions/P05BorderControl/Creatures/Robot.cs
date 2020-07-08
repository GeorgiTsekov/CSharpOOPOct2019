namespace P05BorderControl.Creatures
{
    using P05BorderControl.Contracts;
    using System;

    public class Robot : IIdNumber
    {
        public Robot(string model, string idNumber)
        {
            this.IdNumber = idNumber;
            this.Model = model;
        }

        public string IdNumber { get; private set; }
        public string Model { get; set; }
    }
}
