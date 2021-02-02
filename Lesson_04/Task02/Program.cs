using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    /// <summary>
    /// 2. а) Дописать класс для работы с одномерным массивом. 
    /// Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом. 
    /// Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива, 
    /// метод Multi, умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее количество максимальных элементов. 
    /// В Main продемонстрировать работу класса.
    /// б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    /// </summary>

    class MyArray
    {
        #region Fields

        int[] a;

        #endregion

        #region Constructors

        public MyArray(int[] a)
        {
            var arr = new int[a.Length];
            Array.Copy(a, arr, a.Length);
            this.a = arr;
        }

        public MyArray(int size, int begin, int step)
        {
            a = new int[size];

            for (int i=0; i<size; i++)
            {
                a[i] = begin;
                begin += step;
            }
        }

        public MyArray(int size, int begin, int end, int salt)
        {
            a = new int[size];
            Random rand = new Random(salt);

            for (int i = 0; i < size; i++)
            {
                a[i] = rand.Next(begin, end);
            }
        }

        public MyArray(string fileName)
        {
            if (!File.Exists(fileName))
                //throw new Exception("Файл не существует.");
                throw new FileNotFoundException();
            StreamReader reader = new StreamReader(fileName);
            int size;
            var res = int.TryParse(reader.ReadLine(), out size);
            if (!res)
                throw new Exception("Размер массива должен быть целым числом");
            a = new int[size];
            for (int i = 0; i < Len; i++)
            {
                res = int.TryParse(reader.ReadLine(), out a[i]);
                if (!res)
                    throw new Exception("Элементы массива должны быть целыми числами");
            }
            reader.Close();
        }


        #endregion

        #region Properties

        /// <summary>
        /// Индексное свойство
        /// </summary>
        /// <param name="index">Индекс элемента массива</param>
        /// <returns>Значение элемента массива</returns>
        public int this[int index]
        {
            get { return a[index]; }
            set
            {
                a[index] = value;
            }
        }

        public int Sum
        {
            get
            {
                var sum = 0;
                for (int i=0; i<Len; i++)
                {
                    sum += a[i];
                }
                return sum;
            }
        }

        public int Len
        {
            get { return a.Length; }
        }

        public int Max
        {
            get
            {
                var max = a[0];
                for (int i=0; i<Len; i++)
                {
                    max = (max < a[i]) ? a[i] : max;
                }
                return max;
            }
        }

        public int MaxCount
        {
            get
            {
                var count = 0;
                for (int i = 0; i < Len; i++)
                {
                    count += (a[i] == Max) ? 1 : 0;
                }
                return count;
            }
        }

        public int Min
        {
            get
            {
                var min = a[0];
                for (int i = 0; i < Len; i++)
                {
                    min = (min > a[i]) ? a[i] : min;
                }
                return min;
            }
        }

        public int MinCount
        {
            get
            {
                var count = 0;
                for (int i = 0; i < Len; i++)
                {
                    count += (a[i] == Min) ? 1 : 0;
                }
                return count;
            }
        }

        #endregion

        #region Public Methods

        public int GetValue(int index)
        {
            return a[index];
        }

        public MyArray Multi(int n)
        {
            var arr = new MyArray(a);

            for (int i=0; i<arr.Len; i++)
            {
                arr[i] *= n;
            }

            return arr;
        }

        public MyArray Inverse()
        {
            return Multi(-1);
        }

        public void WriteToFile(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);

            writer.WriteLine(Len);
            for (int i = 0; i < Len; i++)
                writer.WriteLine(a[i]);
            writer.Close();
        }

        public override string ToString()
        {
            string str;
            if (a.Length > 0)
            {
                str = "(" + a[0];
                for (int i = 1; i < a.Length; i++)
                {
                    str += ", " + a[i];
                }
                str += ")";
            }
            else
            {
                str = "";
            }
            return str;
        }

        #endregion

        #region Test Method

        public void Test(string name)
        {
            Console.WriteLine($"Массив {name}: {this}");
            Console.WriteLine($"Размер {name}: {Len}");
            Console.WriteLine($"Сумма элементов {name}: {Sum}");
            Console.WriteLine($"Умножение элементов {name} на 3: {Multi(3)}");
            Console.WriteLine($"Смена знаков {name}: {Inverse()}");
            Console.WriteLine($"Минимальный элемент {name}: {Min}");
            Console.WriteLine($"Количество минимальных элементов {name}: {MinCount}");
            Console.WriteLine($"Максимальный элемент {name}: {Max}");
            Console.WriteLine($"Количество максимальных элементов {name}: {MaxCount}");
            WriteToFile(AppDomain.CurrentDomain.BaseDirectory + $"{name}ArrayTest.txt");
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Массив, созданный по заданию
            var arr1 = new MyArray(20, -23, 7);

            arr1.Test("arr1");

            Console.ReadKey();
            Console.WriteLine();

            // Массив случайных чисел
            var arr2 = new MyArray(20, -10, 10, 45);

            arr2.Test("arr2");

            Console.ReadKey();
            Console.WriteLine();

            // Массив из файла
            var arr3 = new MyArray(AppDomain.CurrentDomain.BaseDirectory + "ArrayTest.txt");

            arr3.Test("arr3");

            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
