using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть к-сть рядків:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[n,n];
            Console.WriteLine("Оберiть спосiб введення масиву: 1 - вручну, 2 - випадково");
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    {
                        MassInput(n, array);
                        Console.WriteLine("Новий масив:");
                        Print(Max(n, array));
                        break;
                    }
                case 2:
                    {
                        CreatingRandomArray(n, array);
                        Print(array);
                        Console.WriteLine("Новий масив:");
                        Print(Max(n, array));
                        break;
                    }
            }

            //Console.WriteLine("Кiлькiсть рядкiв з додатнiми числами:\t" + Max(n, array));
            Console.ReadKey();
        }
        static int[,] MassInput(int n, int[,] array)
        {
            for (int i = 0; i < n; i++)
            {
                string[] numbers = Console.ReadLine().Trim().Split();
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = Convert.ToInt32(numbers[j]);
                }
            }
            return array;
        }
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
        //static int[,] CreatingRandomArray(int n, int[,] array)
        //{
        //    Random r = new Random();
        //    for (int i = 0; i < array.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < array.GetLength(1); j++)
        //        {
        //            array[i, j] = r.Next(-20, 20);
        //        }
        //    }
        //    return array;
        //}
        static int[,] Max(int n, int[,] array)
        {
            int IndexAver;
            int IndexMax;
            for (int i = 0; i < n; i++)
            {
                IndexMax = 0;
                IndexAver = 0;
                for (int j = 1; j < n; j++)
                {
                    if (array[i, j] > array[i, IndexMax])
                    {
                        IndexMax = j;
                    }
                    if (j == i)
                    {
                        IndexAver = j;
                    }
                }
                int temp = array[i, IndexMax];
                array[i, IndexMax] = array[i, IndexAver];
                array[i, IndexAver] = temp;
            }
            return array;
        }       
    }
}