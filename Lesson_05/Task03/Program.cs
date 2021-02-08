using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    /// <summary>
    /// 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
    /// а) с использованием методов C#;
    /// б) * разработав собственный алгоритм.
    /// Например:
    /// badc являются перестановкой abcd.
    /// </summary>
    
    class Program
    {
        static bool isPerm(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;
            return str1.Select(Char.ToUpper).OrderBy(x => x).SequenceEqual(str2.Select(Char.ToUpper).OrderBy(x => x));
        }

        static bool isPermMy(string str1, string str2)
        {
            // В этом методе вторую строку преобразовываем в массив символов.
            // В цикле стараемся массив символов отсортировать по первой строке.

            if (str1.Length != str2.Length)
                return false;

            var carr = str2.ToCharArray();

            for (int i = 0; i < str1.Length; i++)
            {
                var str = new String(carr);
                
                var ind = str.IndexOf(str1[i],i);
                if (ind == -1)
                    return false;
                var temp = carr[ind];
                carr[ind] = carr[i];
                carr[i] = temp;
            }
            return true;

        }

        static void Main(string[] args)
        {
            var str1 = "bacd";
            var str2 = "acdb";
            var str3 = "acdba";
            var str4 = "bbcd";

            Console.WriteLine($"{str1}, {str2}");
            Console.WriteLine((isPerm(str1, str2) ? "Y" : "N"));
            Console.WriteLine($"{str1}, {str3}");
            Console.WriteLine((isPerm(str1, str3) ? "Y" : "N"));
            Console.WriteLine($"{str1}, {str4}");
            Console.WriteLine((isPerm(str1, str4) ? "Y" : "N"));

            Console.ReadKey();

            Console.WriteLine($"{str1}, {str2}");
            Console.WriteLine((isPermMy(str1, str2) ? "Y" : "N"));
            Console.WriteLine($"{str1}, {str3}");
            Console.WriteLine((isPermMy(str1, str3) ? "Y" : "N"));
            Console.WriteLine($"{str1}, {str4}");
            Console.WriteLine((isPermMy(str1, str4) ? "Y" : "N"));

            Console.ReadKey();
        }
    }
}
