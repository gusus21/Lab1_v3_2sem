using System;


namespace lab_1_
{
     class Program
     {
        static void Main(string[] args)
        {
            Console.WriteLine("Введiть к-сть рядкiв:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть к-сть стопчиків(для другого блоку не використовується):");
            int m = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[n, m];
            Console.WriteLine("Оберiть номер блоку, який хочете виконати (вiд 1 до 4) ");
            int choise = int.Parse(Console.ReadLine());
            switch(choise)
            {
                case 1:
                    {
                        DoBlock1(n, m, array);
                        break;
                    }
                case 2:
                    {
                        DoBlock2(n);
                        break;
                    }
                case 3:
                    {
                        DoBlock3(n, m, array);
                        break;
                    }
                case 4:
                    {
                        DoBlock4(n, m, array);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Даний символ не пiдтримується");
                        break;
                    }
            }  
            Console.ReadKey();
        }
        static void DoBlock1(int n, int m, int[,] array)
        {
            Console.WriteLine("Оберiть спосiб введення масиву: 1 - вручну, 2 - випадково");
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    {
                        MassInput(n, m, array);
                        
                        break;
                    }
                case 2:
                    {
                        CreatingRandomArray(n, m, array);
                        PrintArray(array);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Даний символ не пiдтримується");
                        break;
                    }
            }
            OutputOfColumnNumbers(array);
            Console.ReadLine();
        }
        static void DoBlock2(int n)
        {
            int[,] array = new int[n, n];
            Console.WriteLine("Оберiть спосiб введення масиву: 1 - вручну, 2 - випадково");
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    {
                        MassInput(n, n, array);
                        Console.WriteLine("Новий масив:");
                        PrintArray(Max(n, array));
                        Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        CreatingRandomArray(n, n, array);
                        PrintArray(array);
                        Console.WriteLine("Новий масив:");
                        PrintArray(Max(n, array));
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Даний символ не пiдтримується");
                        break;
                    }
            }
        }
        static void DoBlock3(int n, int m, int[,] array)
        {
            Console.WriteLine("Оберiть спосiб введення масиву: 1 - вручну, 2 - випадково");
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    {
                        MassInput(n, m, array);
                        Console.WriteLine("Вiдсортований масив:");
                        for (int i = 0; i < array.GetLength(0); i++)
                        {
                            Sort(m, SumInLaw(i, array), ref array);

                        }
                        PrintArray(array);
                        break;
                    }
                case 2:
                    {
                        CreatingRandomArray(n, m, array);
                        Console.WriteLine("Ваш масив:");
                        PrintArray(array);
                        Console.WriteLine("Вiдсортований масив:");
                        for (int i = 0; i < array.GetLength(0); i++)
                        {
                            Sort(m, SumInLaw(i, array), ref array);

                        }
                        PrintArray(array);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Даний символ не пiдтримується");
                        break;
                    }
                    
            }
        }
        static void DoBlock4(int n, int m, int[,] array)
        {
            Console.WriteLine("Оберiть спосiб введення масиву: 1 - вручну, 2 - випадково");
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    {
                        MassInput(n, m, array);
                        Console.WriteLine("Вiдсортований масив:");
                        QuickSort(MinElem(array), ref array, 0, MinElem(array).Length - 1);
                        PrintArray(array);
                        break;
                    }
                case 2:
                    {
                        CreatingRandomArray(n, m, array);
                        Console.WriteLine("Ваш масив:");
                        PrintArray(array);
                        Console.WriteLine("Вiдсортований масив:");
                        QuickSort(MinElem(array), ref array, 0, MinElem(array).Length - 1);
                        PrintArray(array);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Даний символ не пiдтримується");
                        break;
                    }
            }
        }
        //Введення
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
        //Блок 1
        static void OutputOfColumnNumbers(int[,] array)
        {
            Console.WriteLine("Номери стовбцiв з додатнiми числами для кожного рядка");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] > 0)
                    {
                        Console.Write(j + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        //Блок 2
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
        //Блок 3
        static int SumInLaw(int n, int[,] array)
        {

            int endSum = 0;
            int sum = 1;
            int k = 0;
            for (int i = n; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum *= array[i, j];

                }
                if (sum > endSum)
                {
                    endSum = sum;
                    k = i;
                }
                sum = 1;
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
                    if (array[k, j] > array[k, biggest])
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
        //Блок 4
        static void Swap(ref int x, ref int y)
        {
            var z = x;
            x = y;
            y = z;
        }
        static void QuickSort(int[] array, ref int[,] mass, int left, int right)
        {
            int l = left;
            int r = right;
            int pivot = array[(left + right) / 2];
            do
            {
                while (array[l] < pivot && l < right) l++;

                while (pivot < array[r] && r > left) r--;

                if (l <= r)
                {
                    Swap(ref array[l], ref array[r]);
                    ChangeColumns(ref mass, l, r);
                    l++;
                    r--;
                }
            } while (l <= r);

            if (left < r)
                QuickSort(array, ref mass, left, r);
            if (l < right)
                QuickSort(array, ref mass, l, right);

        }
        static int[] MinElem(int[,] array)
        {
            int[] linArr = new int[array.GetLength(1)];
            int minEl;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                minEl = int.MaxValue;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    if (array[i, j] < minEl)
                    {
                        minEl = array[i, j];
                    }
                }
                linArr[j] = minEl;
            }
            return linArr;
        }
       
        static void ChangeColumns(ref int[,] array, int x, int y)
        {
            int temp;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                temp = array[i, x];
                array[i, x] = array[i, y];
                array[i, y] = temp;
            }
        }   
    }
}
