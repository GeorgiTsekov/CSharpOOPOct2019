﻿
using P03WildFarm.Contracts;
using P03WildFarm.Exceptions;
using System;

namespace P03WildFarm.Models.Foods.Factory
{
    public class FoodFactory
    {
        public IFood ProduceFood(string type, int quantity)
        {
            IFood food;

            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMesseges.InvalidFoodType);
            }

            return food;
        }
    }
}
