using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_VarChange
{
    class Program
    {
        /// <summary>
        /// 4. Написать программу обмена значениями двух переменных.
        /// а) с использованием третьей переменной;
        /// б) *без использования третьей переменной.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Data Input
            Console.Write("Введите значение первой переменной: ");
            var x = int.Parse(Console.ReadLine());
            Console.Write("Введите значение второй переменной: ");
            var y = int.Parse(Console.ReadLine());
            #endregion

            #region Task 1
            Console.WriteLine($"x = {x}; y = {y}");
            var t = x;
            Console.WriteLine($"x = {x}; y = {y}; t = {t}");
            x = y;
            Console.WriteLine($"x = {x}; y = {y}; t = {t}");
            y = t;
            Console.WriteLine($"x = {x}; y = {y}; t = {t}");
            Console.ReadKey();
            #endregion

            #region Task 2
            Console.WriteLine($"x = {x}; y = {y}");
            x = x + y;
            Console.WriteLine($"x = {x}; y = {y}");
            y = y - x;
            Console.WriteLine($"x = {x}; y = {y}");
            y = -y;
            Console.WriteLine($"x = {x}; y = {y}");
            x = x - y;
            Console.WriteLine($"x = {x}; y = {y}");
            Console.ReadKey();
            #endregion

        }
    }
}
