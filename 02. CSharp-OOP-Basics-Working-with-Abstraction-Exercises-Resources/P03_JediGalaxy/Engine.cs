using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_JediGalaxy
{
    public class Engine
    {
        private int[,] matrix;
        private long totalSum;

        public void Run()
        {
            int[] dimestions = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int rows = dimestions[0];
            int cols = dimestions[1];

            InitializeMatrix(rows,cols);

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                int[] jediCoordinates = command.Split(new string[] { " " }, StringSplitOptions
                    .RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRol = evilCoordinates[0];
                int evilCol = evilCoordinates[1];
                MoveEvilToTheRightCorner(evilRol, evilCol);

                int jediRow = jediCoordinates[0];
                int jediCol = jediCoordinates[1];
                MoveJediToTheRightCorner(jediRow, jediCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(totalSum);
        }

        private void MoveJediToTheRightCorner(int jediRow, int jediCol)
        {
            while (jediRow >= 0 && jediCol < matrix.GetLength(1))
            {
                if (IsInside(jediRow, jediCol))
                {
                    totalSum += matrix[jediRow, jediCol];
                }

                jediCol++;
                jediRow--;
            }
        }

        private void MoveEvilToTheRightCorner(int evilRol, int evilCol)
        {
            while (evilRol >= 0 && evilCol >= 0)
            {
                if (IsInside(evilRol, evilCol))
                {
                    matrix[evilRol, evilCol] = 0;
                }
                evilRol--;
                evilCol--;
            }
        }

        private bool IsInside(int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < matrix.GetLength(0) && targetCol >= 0 && targetCol < matrix.GetLength(1);
        }

        public void InitializeMatrix(int rows, int cols)
        {
            matrix = new int[rows, cols];

            int value = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }
    }
}
