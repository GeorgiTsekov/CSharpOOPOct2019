namespace SpaceStation.Models.Bags
{
    using System.Collections.Generic;

    public class Backpack : IBag
    {
        private List<string> items;

        public Backpack()
        {
            this.items = new List<string>();
        }

        public ICollection<string> Items => this.items;
    }
}
