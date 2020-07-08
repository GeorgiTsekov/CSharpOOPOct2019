namespace P03WildFarm.Models.Foods
{
    using P03WildFarm.Contracts;

    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
