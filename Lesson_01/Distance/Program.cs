using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance
{
    class Program
    {
        /// <summary>
        /// 3.
        /// а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
        /// по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
        /// Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
        /// б) *Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода;
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Data Input
            Console.Write("Введите координату X первой точки: ");
            var x1 = int.Parse(Console.ReadLine());
            Console.Write("Введите координату Y первой точки: ");
            var y1 = int.Parse(Console.ReadLine());
            Console.Write("Введите координату X второй точки: ");
            var x2 = int.Parse(Console.ReadLine());
            Console.Write("Введите координату Y второй точки: ");
            var y2 = int.Parse(Console.ReadLine());
            #endregion

            #region Task 1
            var r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine($"Расстояние между двумя точками: {r:f2}");
            Console.ReadKey();
            #endregion

            #region Task 2
            Console.WriteLine($"Расстояние между двумя точками с использованием метода: {Dist(x1,y1,x2,y2):f2}");
            Console.ReadKey();
            #endregion

        }
        #region Method Distance
        static double Dist(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        #endregion
    }
}
