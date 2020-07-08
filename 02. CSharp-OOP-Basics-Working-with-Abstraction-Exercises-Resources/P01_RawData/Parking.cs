using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    public class Parking
    {
        private const int tireCount = 4;

        public Parking()
        {
            this.cars = new List<Car>();
        }

        public List<Car> cars { get; set; }

        public void AddCars(string[] carParameters)
        {
            string model = carParameters[0];

            int engineSpeed = int.Parse(carParameters[1]);
            int enginePower = int.Parse(carParameters[2]);
            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(carParameters[3]);
            string cargoType = carParameters[4];
            Cargo cargo = new Cargo(cargoType, cargoWeight);

            Tire[] tires = GetTires(carParameters.Skip(5).ToList());


            Car car = new Car(model, engine, cargo, tires);

            cars.Add(car);
        }

        public List<Car> GetCars()
        {
            return this.cars;
        }

        private Tire[] GetTires(List<string> tireParameters)
        {
            Tire[] tires = new Tire[tireCount];

            int tireIndex = 0;

            for (int j = 0; j < 8; j += 2)
            {
                double tirePressure = double.Parse(tireParameters[j]);
                int tireAge = int.Parse(tireParameters[j + 1]);

                Tire tire = new Tire(tirePressure, tireAge);

                tires[tireIndex] = tire;

                tireIndex++;
            }

            return tires;
        }
    }
}
