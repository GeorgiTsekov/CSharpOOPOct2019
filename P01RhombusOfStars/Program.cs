using System;
using System.Collections.Generic;

namespace P01RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> stars = new List<int>();

            for (int i = 0; i < n; i++)
            {
                stars.Add(i - 1);
            }

            for (int i = n; i < n + n - 1; i++)
            {
                stars.Add(n + n - 1 - i);
            }

            foreach (var star in stars)
            {
                for (int i = 0; i < star; i++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}
