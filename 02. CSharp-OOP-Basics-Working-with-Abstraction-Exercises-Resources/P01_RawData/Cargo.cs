using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Cargo
    {
        public Cargo(string cargoType, int cargoWeight)
        {
            this.Type = cargoType;
            this.Weight = cargoWeight;
        }

        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
