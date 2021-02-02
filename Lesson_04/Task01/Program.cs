using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        /// <summary>
        /// 1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
        /// Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3. 
        /// В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
        /// </summary>
        /// <param name="args"></param>
        
        #region Task Methods
        static int[] GenArray(int size, int begin, int end)
        {
            // Метод генерации массива

            int[] arr = new int[size];
            Random rand = new Random();

            for (int i=0; i<size; i++)
            {
                arr[i] = rand.Next(begin, end);
            }

            return arr;
        } 
        
        static void PrintArray(int[] arr)
        {
            // Метод вывода массива в консоль

            for (int i=0; i<arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }
        
        static int CheckArray(int[] arr)
        {
            // Метод проверки массива на выполнение условия задачи

            var count = 0;

            for(int i=0; i<(arr.Length-1); i++)
            {
                if (arr[i] % 3 == 0 || arr[i+1] % 3 == 0)
                {
                    count++;
                }
            }

            return count;
        }
        #endregion

        static void Main(string[] args)
        {
            int n = 20;
            int a = -10000;
            int b = 10000;

            var arr1 = GenArray(n, a, b);
            Console.WriteLine("Сгенерированный массив:");
            PrintArray(arr1);

            Console.WriteLine($"Количество пар элементов массива, в которых хотя бы одно число делится на 3: {CheckArray(arr1)}");

            Console.ReadKey();
        }
    }
}
