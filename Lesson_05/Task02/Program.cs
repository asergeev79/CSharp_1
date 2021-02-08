using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{

    /// <summary>
    /// 2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
    /// а) Вывести только те слова сообщения, которые содержат не более n букв.
    /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    /// в) Найти самое длинное слово сообщения.
    /// г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    /// Продемонстрируйте работу программы на текстовом файле с вашей программой.
    /// </summary>
    
    class Message
    {
        static string[] sep = { " ", ".", ",", "!", "?", "-", ":", ";", "\'", "\"", Environment.NewLine };

        public static List<string> StringLenN(string msg, int n)
        {
            var words = msg.Split(sep,StringSplitOptions.RemoveEmptyEntries);
            var lstr = new List<string>();
            for (int i=0; i < words.Length;i++)
            {
                if (words[i].Length <= n)
                    lstr.Add(words[i]);
            }
            return lstr;
        }

        public static string RemoveWordWithChar(string msg, char c)
        {
            var words = msg.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            var message = new StringBuilder(msg);
            for (int i=0; i<words.Length; i++)
            {
                if (words[i][words[i].Length - 1] == c)
                    message.Replace(words[i], "");
            }
            return message.ToString();

        }

        public static List<string> LongestWord(string msg)
        {
            var maxwords = new List<string>();
            var words = msg.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            var maxlen = 0;
            for (int i=0; i < words.Length; i++)
            {
                if (words[i].Length > maxlen)
                    maxlen = words[i].Length;
            }
            for(int i=0; i < words.Length; i++)
            {
                if (words[i].Length == maxlen)
                    maxwords.Add(words[i]);
            }
            return maxwords;
        }

        public static string LongestWordsJoin(string msg)
        {
            var strbuild = new StringBuilder();
            foreach (string str in LongestWord(msg))
            {
                strbuild.Append(str);
            }
            return strbuild.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var message = @"Требуется написать как можно более эффективную программу, которая будет выводить на экран
фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
Достаточно решить 2 задачи. Старайтесь разбивать программы на подпрограммы. Переписывайт в
начало программы условие и свою фамилию. Все программы сделать в одном решении. Для решения
задач используйте неизменяемые строки (string)";

            foreach (string str in Message.StringLenN(message, 4))
                Console.WriteLine(str);

            Console.ReadKey();

            Console.WriteLine(Message.RemoveWordWithChar(message, 'х'));
            Console.ReadKey();

            foreach (string str in Message.LongestWord(message))
                Console.WriteLine(str);
            Console.ReadKey();

            Console.WriteLine(Message.LongestWordsJoin(message));
            Console.ReadKey();

        }
    }
}
