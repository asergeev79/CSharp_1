using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        /// <summary>
        /// 2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). 
        /// Требуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse;
        /// б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
        /// При возникновении ошибки вывести сообщение.Напишите соответствующую функцию;
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var sum = 0;
            int num;
            Console.Clear();
            Console.WriteLine("Программа подсчёта суммы всех нечетных положительных чисел.");
            
            do
            {
                Console.Write("Введите число (0 - выход): ");
                var res = int.TryParse(Console.ReadLine(), out num);
                if (res)
                {
                    sum += ((num % 2 != 0) && (num > 0)) ? num : 0;
                }
                else
                {
                    Console.WriteLine("Ошибка! Необходимо вводить целые числа.");
                    num = -1;
                }
            } while (num != 0);

            Console.WriteLine($"Сумма всех нечетных положительных чисел: {sum}");
            Console.ReadKey();
        }
    }
}
