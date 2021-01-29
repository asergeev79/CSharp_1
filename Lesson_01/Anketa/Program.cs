using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anketa
{
    class Program
    {
        /// <summary>
        /// Андрей Сергеев
        /// 1. Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
        /// В результате вся информация выводится в одну строчку.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Data Input
            Console.Write("Введите имя: ");
            var name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            var surname = Console.ReadLine();
            Console.Write("Введите возраст: ");
            var age = Console.ReadLine();
            Console.Write("Введите рост: ");
            var height = Console.ReadLine();
            Console.Write("Введите вес: ");
            var weight = Console.ReadLine();
            #endregion

            #region Task 1
            // а) используя склеивание;
            Console.WriteLine("Склеивание строк. ФИО: " + name + " " + surname + ". Возраст: " + age + ". Рост: " + height + ". Вес: " + weight);
            Console.ReadKey();
            #endregion

            #region Task 2
            // б) используя форматированный вывод;
            Console.WriteLine("Форматированный вывод. ФИО: {0} {1}. Возраст: {2}. Рост: {3}. Вес: {4}", name, surname, age, height, weight);
            Console.ReadKey();
            #endregion

            #region Task 3
            // в) *используя вывод со знаком $.
            Console.WriteLine($"Интерполяция строк. ФИО: {name} {surname}. Возраст: {age}. Рост: {height}. Вес: {weight}");
            Console.ReadKey();
            #endregion

        }
    }
}
