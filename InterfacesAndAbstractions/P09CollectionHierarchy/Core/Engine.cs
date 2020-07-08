using P09CollectionHierarchy.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace P09CollectionHierarchy.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] items = Console.ReadLine()
                .Split(" ");

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> firstCollection = new List<int>();
            List<int> secondCollection = new List<int>();
            List<int> thirdCollection = new List<int>();

            foreach (var item in items)
            {
                firstCollection.Add(addCollection.Add(item));
                secondCollection.Add(addRemoveCollection.Add(item));
                thirdCollection.Add(myList.Add(item));
            }
            Console.WriteLine(string.Join(" ", firstCollection));
            Console.WriteLine(string.Join(" ", secondCollection));
            Console.WriteLine(string.Join(" ", thirdCollection));

            int removeOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
        }
    }
}
