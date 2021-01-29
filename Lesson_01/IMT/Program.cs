using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT
{
    class Program
    {
        /// <summary>
        /// 2. Ввести вес и рост человека. 
        /// Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
        /// где m — масса тела в килограммах, h — рост в метрах
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Data Input
            Console.Write("Введите рост в сантиметрах: ");
            var h = float.Parse(Console.ReadLine());
            Console.Write("Введите вес в килограммах: ");
            var m = float.Parse(Console.ReadLine());
            #endregion

            #region Task
            var I = m * 10000 / (h * h);
            Console.WriteLine($"Индекс массы тела: {I}");
            Console.ReadKey();
            #endregion
        }
    }
}
