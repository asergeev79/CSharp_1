using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task01
{
    /// <summary>
    /// 1. Создать программу, которая будет проверять корректность ввода логина. 
    /// Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    /// а) без использования регулярных выражений;
    /// б) с использованием регулярных выражений.
    /// </summary>

    
    
    class Program
    {
        static bool isLoginCorrectRegex(string str)
        {
            if (str.Length < 2 || str.Length > 10)
            {
                return false;
            }
            return Regex.IsMatch(str, @"^[A-Za-z][a-zA-Z0-9]+");
        }

        static bool isLoginCorrect(string str)
        {
            if (str.Length < 2 || str.Length > 10)
            {
                return false;
            }
            if (!Char.IsLetter(str[0]))
                return false;
            for (int i = 1; i < str.Length; i++)
                if (!Char.IsLetterOrDigit(str[i]))
                    return false;
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите логин");
            var login = Console.ReadLine();

            Console.WriteLine("Проверка с регулярными выражениями:");
            if (isLoginCorrectRegex(login))
                Console.WriteLine("Логин корректный");
            else
                Console.WriteLine("Логин некорректный");

            Console.WriteLine("Проверка без регулярных выражений:");
            if (isLoginCorrect(login))
                Console.WriteLine("Логин корректный");
            else
                Console.WriteLine("Логин некорректный");

            Console.ReadKey();
        }
    }
}
