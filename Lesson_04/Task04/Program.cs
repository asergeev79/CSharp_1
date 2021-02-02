using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    /// <summary>
    /// 4. *а) Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. 
    /// Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, 
    /// свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, 
    /// метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)
    /// * б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    /// Дополнительные задачи
    /// в) Обработать возможные исключительные ситуации при работе с файлами.
    /// </summary>

    class MyArray2D
    {
        #region Fields

        int[,] a2d;

        #endregion

        #region Constructors

        public MyArray2D(int[,] a)
        {
            var arr = new int[a.GetLength(0),a.GetLength(1)];
            Array.Copy(a, arr, a.Length);
            this.a2d = arr;
        }

        public MyArray2D(int size0, int size1, int begin, int end)
        {
            a2d = new int[size0,size1];
            Random rand = new Random();

            for (int i = 0; i < size0; i++)
                for (int j=0; j<size1; j++)
                {
                    a2d[i,j] = rand.Next(begin, end);
                }
        }

        public MyArray2D(string fileName)
        {
            if (!File.Exists(fileName))
                //throw new Exception("Файл не существует.");
                throw new FileNotFoundException();
            StreamReader reader = new StreamReader(fileName);
            int size0,size1;
            var res = int.TryParse(reader.ReadLine(), out size0);
            if (!res)
                throw new Exception("Размер массива должен быть целым числом");
            res = int.TryParse(reader.ReadLine(), out size1);
            if (!res)
                throw new Exception("Размер массива должен быть целым числом");
            a2d = new int[size0,size1];
            for (int i = 0; i < size0; i++)
                for (int j = 0; j < size1; j++)
                {
                    res = int.TryParse(reader.ReadLine(), out a2d[i,j]);
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
        public int this[int index0,int index1]
        {
            get { return a2d[index0,index1]; }
            set
            {
                a2d[index0,index1] = value;
            }
        }

        public int Len0
        {
            get { return a2d.GetLength(0); }
        }

        public int Len1
        {
            get { return a2d.GetLength(1); }
        }

        public int Sum
        {
            get
            {
                var sum = 0;
                for (int i = 0; i < Len0; i++)
                    for (int j = 0; j < Len1; j++)
                    {
                        sum += a2d[i,j];
                    }
                return sum;
            }
        }

        public int Max
        {
            get
            {
                var max = a2d[0,0];
                for (int i = 0; i < Len0; i++)
                    for (int j = 0; j < Len1; j++)
                    {
                        max = (max < a2d[i,j]) ? a2d[i,j] : max;
                    }
                return max;
            }
        }

        public int MaxCount
        {
            get
            {
                var count = 0;
                for (int i = 0; i < Len0; i++)
                    for (int j = 0; j < Len1; j++)
                    {
                        count += (a2d[i,j] == Max) ? 1 : 0;
                }
                return count;
            }
        }

        public int Min
        {
            get
            {
                var min = a2d[0,0];
                for (int i = 0; i < Len0; i++)
                    for (int j = 0; j < Len1; j++)
                    {
                        min = (min > a2d[i,j]) ? a2d[i,j] : min;
                    }
                return min;
            }
        }

        public int MinCount
        {
            get
            {
                var count = 0;
                for (int i = 0; i < Len0; i++)
                    for (int j = 0; j < Len1; j++)
                    {
                        count += (a2d[i,j] == Min) ? 1 : 0;
                    }
                return count;
            }
        }

        #endregion

        #region Public Methods

        public int GetValue(int index0,int index1)
        {
            return a2d[index0,index1];
        }

        public MyArray2D Multi(int n)
        {
            var arr = new MyArray2D(a2d);

            for (int i = 0; i < arr.Len0; i++)
                for (int j = 0; j < arr.Len1; j++)
                {
                    arr[i,j] *= n;
                }

            return arr;
        }

        public MyArray2D Inverse()
        {
            return Multi(-1);
        }

        public void WriteToFile(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);

            writer.WriteLine($"{Len0} {Len1}");
            for (int i = 0; i < Len0; i++)
            {
                for (int j = 0; j < Len1; j++)
                    writer.Write($"{a2d[i,j]} ");
                writer.WriteLine();
            }
            writer.Close();
        }

        public void PrintArray2D()
        {
            for (int i = 0; i < Len0; i++)
            {
                for (int j = 0; j < Len1; j++)
                    Console.Write($"{a2d[i,j]} ");
                Console.WriteLine();
            }
        }

        public int SumOverN(int n)
        {
            var sum = 0;
            for (int i = 0; i < Len0; i++)
                for (int j = 0; j < Len1; j++)
                {
                    sum += (a2d[i, j] > n) ? a2d[i, j] : 0;
                }
            return sum;
        }

        public void IndexOf(int el, out int index0, out int index1)
        {
            for (int i = 0; i < Len0; i++)
                for (int j = 0; j < Len1; j++)
                {
                    if (a2d[i, j] == el)
                    {
                        index0 = i;
                        index1 = j;
                        return;
                    }
                }
            index0 = -1;
            index1 = -1;
        }

        public void IndexOfMin(out int index0, out int index1)
        {
            int ind0, ind1;
            IndexOf(Min, out ind0, out ind1);
            index0 = ind0;
            index1 = ind1;
        }

        public void IndexOfMax(out int index0, out int index1)
        {
            int ind0, ind1;
            IndexOf(Max, out ind0, out ind1);
            index0 = ind0;
            index1 = ind1;
        }

        #endregion

        #region Test Method

        public void Test(string name)
        {
            Console.WriteLine($"Массив {name}:");
            PrintArray2D();
            Console.WriteLine($"Размер {name}: ({Len0},{Len1})");
            Console.WriteLine($"Сумма элементов {name}: {Sum}");
            Console.WriteLine($"Сумма элементов {name}, больших 5: {SumOverN(5)}");
            Console.WriteLine($"Минимальный элемент {name}: {Min}");
            int index0, index1;
            IndexOfMin(out index0, out index1);
            Console.WriteLine($"Индекс минимального элемента {name}: ({index0},{index1})");
            Console.WriteLine($"Максимальный элемент {name}: {Max}");
            IndexOfMax(out index0, out index1);
            Console.WriteLine($"Индекс максимального элемента {name}: ({index0},{index1})");
            WriteToFile(AppDomain.CurrentDomain.BaseDirectory + $"{name}ArrayTest.txt");
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Массив случайных чисел
            var arr2 = new MyArray2D(5,4, -10, 10);

            arr2.Test("arr2");

            Console.ReadKey();
            Console.WriteLine();

            // Массив из файла
            var arr3 = new MyArray2D(AppDomain.CurrentDomain.BaseDirectory + "ArrayTest.txt");

            arr3.Test("arr3");

            Console.ReadKey();
            Console.WriteLine();

        }
    }
}
