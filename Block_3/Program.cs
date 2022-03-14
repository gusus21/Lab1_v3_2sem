using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть к-сть рядків:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть к-сть стопчиків:");
            int m = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[n, m];
            Console.WriteLine("Оберiть спосiб введення масиву: 1 - вручну, 2 - випадково");
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    {
                        MassInput(n, m, array);
                        Console.WriteLine("Вiдсортований масив:");
                        //PrintArray(Sort(m, SumInLaw(0, array), ref array));
                       // Console.WriteLine();
                        PrintArray(Sort(m, SumInLaw(SumInLaw(0, array) + 1, array), ref array));
                        break;
                    }
                case 2:
                    {
                        CreatingRandomArray(n, m, array);
                        Console.WriteLine("Ваш масив:");
                        PrintArray(array);
                        Console.WriteLine("Вiдсортований масив:");
                        Sort(m, SumInLaw(0, array), ref array);
                        PrintArray(Sort(m, SumInLaw(SumInLaw(0, array) + 1, array), ref array));
                        break;
                    }
            }

            
            Console.ReadKey();
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
        static int[,] CreatingRandomArray(int n, int m, int[,] array)
        {
            Random r = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = r.Next(-20, 20);
                }
            }
            return array;
        }
        static void PrintArray(int[,] array)
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
        static int SumInLaw(int n, int[,] array)
        {

            int endSum = 0;
            int sum = 0;
            int k = 0;
            for (int i = n; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];

                }
                if (sum < endSum)
                {
                    endSum = sum;
                    k = i;
                }
                sum = 0;
            }
            return k;
        }
        static int[,] Sort(int n, int k, ref int[,] array)
        {
            int temp, biggest;

            for (int i = 0; i < n - 1; i++)
            {
                biggest = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[k, j] < array[k, biggest])
                    {
                        biggest = j;
                    }
                }
                temp = array[k, biggest];
                array[k, biggest] = array[k, i];
                array[k, i] = temp;
            }
            return array;
        }
    }
}
