namespace P09CollectionHierarchy.Collections
{
    using System.Collections.Generic;
    using System.Text;
    using P09CollectionHierarchy.Collections.Contracts;

    public class AddCollection : IAddCollection
    {
        private List<string> elements;
        public AddCollection()
        {
            this.elements = new List<string>();
        }

        public int Add(string item)
        {
            elements.Add(item);

            int lastIndex = this.elements.Count - 1;
            return lastIndex;
        }
    }
}
