using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабараторна__1
{
    class Program
    {
        static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[,] MassInput(int n, int m, int[,] array)
        {
            for (int i = 0; i < n; i++)
            {
                string[] numbers = Console.ReadLine().Trim().Split();
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = Convert.ToInt32(numbers[j]);
                }
            }
            return array;
        }
        static void MinElAndIndex(int[,] array)
        {
            int min = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int index1 = 0;
                int index2 = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] <= min)
                    {
                        min = array[i, j];
                        index1 = i;
                        index2 = j;
                    }
                }
                Console.WriteLine($"Мінімальний елемент рядочка {0}: {min}, а його індекси [{index1},{index2}]", i);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть розмір матриці");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] array = new int[n, m];
            MassInput(n, m, array);
            MinElAndIndex(array);
        }
    }
}
