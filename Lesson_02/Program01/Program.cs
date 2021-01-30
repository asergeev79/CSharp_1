using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program01
{
    class Program
    {
        #region Task 7
        static void PrintAB(int num1, int num2)
        {
            // рекурсивный метод, который выводит на экран числа от a до b
            // Здесь нет чёткого требования a<b
            Console.WriteLine(num1);
            if (num1 < num2) 
            {
                PrintAB(num1 + 1, num2);
            }
            else if (num1 > num2)
            {
                PrintAB(num1 - 1, num2);
            }
        }
        static int SumAB(int num1, int num2)
        {
            // рекурсивный метод, который считает сумму чисел от a до b
            if (num1 < num2)
            {
                Console.Write($"{num1} + ");
                return SumAB(num1 + 1, num2) + num1;
            }
            else if (num1 > num2)
            {
                Console.Write($"{num1} + ");
                return SumAB(num1 - 1, num2) + num1;
            }
            Console.Write($"{num1} = ");
            return num1;
        }
        static void Task7()
        {
            // 7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b (a<b);
            // б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
            Console.WriteLine("Введите 2 целых числа");
            Console.Write("Первое число: ");
            var a = int.Parse(Console.ReadLine());
            Console.Write("Второе число: ");
            var b = int.Parse(Console.ReadLine());

            Console.WriteLine($"Все числа от {a} до {b}: ");
            PrintAB(a, b);
            Console.Write($"Сумма чисел от {a} до {b}: ");
            Console.WriteLine($"{SumAB(a, b)}");
            Console.ReadKey();            
        }
        #endregion

        #region Task 6
        static int SumNum(int num)
        {
            // подсчёт суммы цифр числа
            var sum = 0;
            while(num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
        static bool isGood(int num)
        {
            // проверка делимости числа на сумму своих цифр
            return (num % SumNum(num) == 0) ? true : false;
        }
        static void Task6()
        {
            // 6. *Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000. 
            // Хорошим называется число, которое делится на сумму своих цифр. 
            // Реализовать подсчет времени выполнения программы, используя структуру DateTime.
            DateTime date1 = DateTime.Now; 
            var count = 0;
            for(int i=1; i<=1000000;i++)
            {
                if (isGood(i))
                {
                    //Console.WriteLine($"Число {i} - хорошее");
                    count++;
                }
            }
            Console.WriteLine($"В диапазоне от 1 до 1 млн - {count} 'хороших' чисел");
            Console.WriteLine($"Время выполнения в миллисекундах: {(DateTime.Now - date1).TotalMilliseconds}");
            Console.ReadKey();
        }
        #endregion

        #region Task 5
        static void Task5()
        {
            // 5.а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, 
            // нужно ли человеку похудеть, набрать вес или все в норме;
            // б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
            Console.Write("Введите массу в кг: ");
            var weight = int.Parse(Console.ReadLine());
            Console.Write("Введите рост в см: ");
            float height = float.Parse(Console.ReadLine()) / 100;

            float index = weight / (height * height);
            Console.WriteLine($"Индекс массы тела: {index:f2}");
            if(index <= 16)
            {
                Console.WriteLine("Выраженный дефицит массы тела");
                Console.WriteLine($"Необходимо набрать: {(18.5 - index) * height * height} кг");
            }
            else if (index < 18.5) 
            {
                Console.WriteLine("Недостаточная (дефицит) масса тела");
                Console.WriteLine($"Необходимо набрать: {(18.5 - index) * height * height} кг");
            }
            else if (index < 25)
            {
                Console.WriteLine("Норма");
                Console.WriteLine($"Так держать!");
            }
            else if (index < 30)
            {
                Console.WriteLine("Избыточная масса тела (предожирение)");
                Console.WriteLine($"Необходимо похудеть на {(index - 25) * height * height} кг");
            }
            else if (index < 35)
            {
                Console.WriteLine("Ожирение");
                Console.WriteLine($"Необходимо похудеть на {(index - 25) * height * height} кг");
            }
            else if (index < 40)
            {
                Console.WriteLine("Ожирение резкое");
                Console.WriteLine($"Необходимо похудеть на {(index - 25) * height * height} кг");
            }
            else
            {
                Console.WriteLine("Очень резкое ожирение");
                Console.WriteLine($"Необходимо похудеть на {(index - 25) * height * height} кг");
            }
            Console.ReadKey();
        }
        #endregion

        #region Task 4
        static bool CheckLogPass(string username, string password)
        {
            var login = "root";
            var pass = "GeekBrains";

            return ((login == username) && (pass == password)) ? true : false;
        }
        static void Task4()
        {
            // 4. Реализовать метод проверки логина и пароля. На вход подается логин и пароль. 
            // На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
            // Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
            // С помощью цикла do while ограничить ввод пароля тремя попытками.
            var count = 0;

            Console.Write("Введите имя пользователя: ");
            var login = Console.ReadLine();
            do
            {
                Console.Write("Введите пароль: ");
                var pass = Console.ReadLine();
                if (CheckLogPass(login, pass))
                {
                    Console.WriteLine("Вы вошли в систему!");
                    Console.ReadKey();
                    return;
                }
                count++;
                Console.WriteLine("Неверное имя пользователя или пароль!");
                Console.WriteLine($"Попыток: {count}");
            } while (count < 3);
            Console.WriteLine("Превышено число попыток!");
            Console.ReadKey();
        }
        #endregion

        #region Task 3
        static void Task3()
        {
            // 3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
            var sum = 0;
            int num;
            do
            {
                Console.Write("Введите очередное число (0 - выход): ");
                num = int.Parse(Console.ReadLine());
                if ((num % 2 != 0) && (num > 0))
                {
                    sum += num;
                }
            } while (num != 0);
            Console.WriteLine($"Сумма нечетных положительных чисел: {sum}");
            Console.ReadKey();
        }
        #endregion

        #region Task 2
        static int CountNum(int num)
        {
            // var str = num.ToString();
            // return str.Length;

            var count = 0;
            while(num != 0)
            {
                num /= 10;
                count++;
            }
            return count;
        }
        static void Task2()
        {
            // 2. Написать метод подсчета количества цифр числа.
            Console.Write("Введите число: ");
            var num = int.Parse(Console.ReadLine());
            Console.WriteLine($"Количество цифр в числе: {CountNum(num)}");
            Console.ReadKey();
        }
        #endregion

        #region Task 1
        static int Min3(int n1, int n2, int n3)
        {
            if ((n1 <= n2) && (n1 <= n3))
            {
                return n1;
            }
            else if ((n2 <= n1) && (n2 <= n3))
            {
                return n2;
            }
            else
            {
                return n3;
            }
        }
        static void Task1()
        {
            // 1. Написать метод, возвращающий минимальное из трех чисел.
            Console.Write("Введите первое число: ");
            var a = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            var b = int.Parse(Console.ReadLine());
            Console.Write("Введите третье число: ");
            var c = int.Parse(Console.ReadLine());

            Console.WriteLine($"Минимальное число: {Min3(a, b, c)}");
            Console.ReadKey();
        }
        #endregion

        static void Main(string[] args)
        {
            int task;
            do
            {
                Console.Clear();
                Console.Write("Введите номер задачи (0 - выход): ");
                task = int.Parse(Console.ReadLine());

                switch (task)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
                        break;
                    case 6:
                        Task6();
                        break;
                    case 7:
                        Task7();
                        break;
                }

            } while (task != 0);
        }
    }
}
