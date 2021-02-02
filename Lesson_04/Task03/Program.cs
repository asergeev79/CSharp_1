using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    /// <summary>
    /// 3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив. 
    /// Создайте структуру Account, содержащую Login и Password.
    /// </summary>
    class Program
    {
        struct Account
        {
            public string login;
            public string password;

            public bool CheckPass(Account acc)
            {
                if (login == acc.login && password == acc.password)
                    return true;
                else
                    return false;
            }

            public override string ToString()
            {
                return $"{login}:{password}";
            }

        }

        #region Help Methods

        static Account StrToAcc(string s)
        {
            // Перевод строки в пару логин/пароль
            Account acc;
            string[] logpass = s.Split(new char[] { '/' });
            acc.login = logpass[0];
            acc.password = logpass[1];
            return acc;
        }

        static List<Account> ReadLinesFromFile(string filename)
        {
            // Чтение учёток из файла
            if (!File.Exists(filename))
                //throw new Exception("Файл не существует.");
                throw new FileNotFoundException();
            StreamReader reader = new StreamReader(filename);

            var lines = new List<Account>();
            while (!reader.EndOfStream)
            {
                lines.Add(StrToAcc(reader.ReadLine()));
            }

            reader.Close();

            return lines;        
        }

        #endregion

        static void Main(string[] args)
        {
            Console.Clear();

            var accounts = ReadLinesFromFile(AppDomain.CurrentDomain.BaseDirectory + "AccountsTest.txt");

            //foreach (var account in accounts)
            //    Console.WriteLine(account);

            // Console.ReadKey();

            Account acc1;
            Console.Write("Введите имя пользователя: ");
            acc1.login = Console.ReadLine();
            var count = 0;
            do
            {
                count++;
                Console.WriteLine($"Попытка {count}");

                Console.Write("Введите пароль: ");
                acc1.password = Console.ReadLine();

                foreach (var account in accounts)
                {
                    if (acc1.CheckPass(account))
                    {
                        Console.WriteLine("Вход успешен!");
                        Console.ReadKey();
                        return;
                    }
                }
                Console.WriteLine("Имя пользователя или пароль неверны.");

            } while (count < 3);

            Console.WriteLine("Вход неуспешен!");
            Console.ReadKey();

        }
    }
}
