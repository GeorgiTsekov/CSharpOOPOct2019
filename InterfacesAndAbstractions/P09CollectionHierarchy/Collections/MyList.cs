namespace P09CollectionHierarchy.Collections
{
    using System;
    using System.Collections.Generic;
    using P09CollectionHierarchy.Collections.Contracts;

    public class MyList : IMyList
    {
        private List<string> elements;
        public MyList()
        {
            this.elements = new List<string>();
        }

        public int Used => elements.Count;

        public int Add(string item)
        {
            this.elements.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            if (elements.Count <= 0)
            {
                throw new ArgumentException("Cannot remove elements if collection is empty!");
            }

            string removedElement = this.elements[0];

            this.elements.RemoveAt(0);

            return removedElement;
        }
    }
}
