namespace P09CollectionHierarchy.Collections
{
    using System;
    using System.Collections.Generic;
    using P09CollectionHierarchy.Collections.Contracts;

    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> elements;

        public AddRemoveCollection()
        {
            this.elements = new List<string>();
        }

        public int Add(string item)
        {
            this.elements.Insert(0, item);

            int firstIndex = 0;

            return firstIndex;
        }

        public string Remove()
        {
            if (elements.Count <= 0)
            {
                throw new ArgumentException("Cannot remove elements if collection is empty!");
            }
            string removedElement = this.elements[elements.Count - 1];

            this.elements.RemoveAt(elements.Count - 1);

            return removedElement;
        }
    }
}
