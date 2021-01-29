using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace _05_DataPrint
{
    class Program
    {
        /// <summary>
        /// 5.
        /// а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
        /// б) Сделать задание, только вывод организуйте в центре экрана
        /// в) *Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var name = "Андрей";
            var surname = "Сергеев";
            var city = "Москва";
            var ManData = $"{name} {surname}, {city}";

            #region Task 1
            Console.WriteLine(ManData);
            Console.ReadKey();
            #endregion

            #region Task 2
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - ManData.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(ManData);
            Console.ReadKey();
            #endregion

            #region Task 3
            Console.Clear();
            Output.Print(ManData, (Console.WindowWidth - ManData.Length) / 4, Console.WindowHeight / 2);
            Output.Pause();
            #endregion
        }
    }
}
