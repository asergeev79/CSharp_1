using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    /// <summary>
    /// 4. Задача ЕГЭ.
    /// * На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
    /// школы.В первой строке сообщается количество учеников N, которое не меньше 10, но не
    /// превосходит 100, каждая из следующих N строк имеет следующий формат:
    /// <Фамилия> <Имя> <оценки>,
    /// где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
    /// более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
    /// пятибалльной системе. <Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом.
    /// Пример входной строки:
    /// Иванов Петр 4 5 3
    /// Требуется написать как можно более эффективную программу, которая будет выводить на экран
    /// фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
    /// набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
    /// Достаточно решить 2 задачи.Старайтесь разбивать программы на подпрограммы.Переписывайте в
    /// начало программы условие и свою фамилию. Все программы сделать в одном решении. Для решения
    /// задач используйте неизменяемые строки (string)
    /// </summary>

    class Student
    {
        string name;
        string surname;
        int[] score = new int[3] { 0, 0, 0 };

        #region Constructors
        public Student(string surname, string name)
        {
            if (name.Length > 15)
                Console.WriteLine("Имя должно быть не больше 15 символов");
            else
                this.name = name;
            if (surname.Length > 20)
                Console.WriteLine("Фамилия должна быть не больше 20 символов");
            else
                this.surname = surname;
        }

        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Имя должно быть не больше 15 символов");
                else
                    name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (value.Length > 20)
                    Console.WriteLine("Фамилия должна быть не больше 20 символов");
                else
                    surname = value;
            }
        }
        public string FullName
        {
            get
            {
                return $"{name} {surname}";
            }

        }

        public int[] Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public int SumScore
        {
            get
            {
                return (score[0] + score[1] + score[2]);
            }
        }

        public double AverageScore
        {
            get
            {
                return (double)SumScore / 3;
            }
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"Студент: {FullName}. Оценки: ({Score[0]}, {Score[1]}, {Score[2]}). Средний балл: {AverageScore}.";
        }

        #endregion
    }

    class SchoolClass
    {
        int num;
        Student[] students;
        int[] worstScore;

        #region Constructors

        public SchoolClass(int n)
        {
            if (n < 10 || n > 100)
                throw new Exception("Количество учеников должно быть от 10 до 100");
            num = n;
            students = new Student[num];
        }
        public SchoolClass(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                var res = int.TryParse(sr.ReadLine(),out num);
                if (!res)
                    throw new Exception("Количество учеников должно быть целым числом");

                students = new Student[num];

                for (int i = 0; i < num; i++)
                {
                    var student = sr.ReadLine();
                    if (student == null)
                        throw new Exception($"Нет данных по {i}-му ученику");
                    var studarr = student.Split(' ');
                    students[i] = new Student(studarr[0], studarr[1]);
                    students[i].Score = new int[3] { int.Parse(studarr[2]), int.Parse(studarr[3]), int.Parse(studarr[4]) };
                }
            }
            var averscores = new List<int>();
            for (int i = 0; i < Num; i++)
                averscores.Add(students[i].SumScore);
            worstScore = averscores.Distinct().ToArray();
            Array.Sort(worstScore);
        }

        #endregion

        #region Properties

        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }

        #endregion

        #region Public Methods

        public void PrintClass()
        {
            for (int i = 0; i < Num; i++)
                Console.WriteLine(students[i].ToString());
        }

        public void PrintWorst()
        {

            for (int j=0; j<3; j++)
            {
                Console.WriteLine($"Средний балл: {(double)worstScore[j] / 3}");
                for (int i = 0; i < Num; i++)
                    if (students[i].SumScore == worstScore[j])
                        Console.WriteLine(students[i].ToString());
            }
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            var newClass = new SchoolClass(AppDomain.CurrentDomain.BaseDirectory + "ClassTest.txt");

            newClass.PrintClass();
            Console.ReadKey();

            newClass.PrintWorst();
            Console.ReadKey();

        }
    }
}
