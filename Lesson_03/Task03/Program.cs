using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    /// <summary>
    /// 3. *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. 
    /// Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
    /// Написать программу, демонстрирующую все разработанные элементы класса. 
    /// ** Добавить проверку, чтобы знаменатель не равнялся 0. 
    /// Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
    /// Добавить упрощение дробей.
    /// </summary>

    class Ratio
    {

        #region Private Fields

        // Числитель
        private int num;

        // Знаменатель
        private int den;

        #endregion

        #region Public Properties
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

        public int Den
        {
            get
            {
                return den;
            }

            set
            {
                if(value == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
                den = value;
            }
        }
        #endregion

        #region Constructors
        public Ratio()
        {
        }
        public Ratio(int num)
        {
            this.num = num;
            this.den = 1;
        }

        public Ratio(int num, int den)
        {
            this.num = num;
            if (den == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            this.den = den;
        }
        #endregion

        #region Private Methods
        private int nod(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return Math.Abs(a - b);
            }
            while (a != b)
            {
                if (a > b)
                {
                    int tmp = a;
                    a = b;
                    b = tmp;
                }
                b = b - a;
            }
            return a;
        }
        private int nok(int a, int b)
        {
            if(a == 0 || b == 0)
            {
                throw new DivideByZeroException();
            }
            return a * b / nod(a, b);
        }


        #endregion

        #region Public Methods
        public Ratio Simplify() 
        {
            var sign = Math.Sign(num * den);
            var tnum = Math.Abs(num) * sign;
            var tden = Math.Abs(den);
            int gcd;

            if(tnum == 0)
            {
                gcd = tden;
            }
            else
            {
                gcd = nod(Math.Abs(tnum), tden);
            }
            tnum /= gcd;
            tden /= gcd;
            return new Ratio(tnum, tden);
        }
        public Ratio Reverse()
        {
            if(num != 0)
            {
                return new Ratio(den, num).Simplify();
            }
            return this.Simplify();
        }

        public Ratio Plus(Ratio r)
        {
            return new Ratio(Num * r.Den + r.Num * Den, den * r.Den).Simplify();
        }
        public static Ratio operator +(Ratio ratio1, Ratio ratio2)
        {
            return new Ratio { Num = ratio1.Num * ratio2.Den + ratio1.Den * ratio2.Num, Den = ratio1.Den * ratio2.Den }.Simplify();
        }

        public Ratio Subtract(Ratio r)
        {
            return new Ratio(Num * r.Den - r.Num * Den, den * r.Den).Simplify();
        }
        public static Ratio operator -(Ratio ratio1, Ratio ratio2)
        {
            return new Ratio { Num = ratio1.Num * ratio2.Den - ratio1.Den * ratio2.Num, Den = ratio1.Den * ratio2.Den }.Simplify();
        }

        public Ratio Multiply(Ratio r)
        {
            return new Ratio(num * r.num,den * r.den).Simplify();
        }
        public static Ratio operator *(Ratio ratio1, Ratio ratio2)
        {
            return new Ratio { Num = (ratio1.Num * ratio2.Num), Den = (ratio1.Den * ratio2.Den) }.Simplify();
        }

        public Ratio Divide(Ratio r)
        {
            if (r.Num != 0)
            {
                return new Ratio(num * r.Den, den * r.Num).Simplify();
            }
            else
            {
                throw new ArgumentException("На ноль делить нельзя");
            }
        }
        public static Ratio operator /(Ratio ratio1, Ratio ratio2)
        {
            if (ratio2.Num != 0)
            {
                return new Ratio { Num = (ratio1.Num * ratio2.Den), Den = (ratio1.Den * ratio2.Num) }.Simplify();
            }
            else
            {
                throw new ArgumentException("На ноль делить нельзя");
            }
        }

        public override string ToString()
        {
            return $"({num}/{den})";
        }

        #endregion

    }
    class Program
    {
        static void Main(string[] args)
        {
            var r1 = new Ratio();
            r1.Num = 1;
            r1.Den = 5;

            var r2 = new Ratio(2, 3);

            var r3 = new Ratio();
            r3.Num = -4;
            r3.Den = 18;

            var r4 = new Ratio(-63, -15);

            var r5 = new Ratio(0);

            Console.WriteLine($"r1={r1} r2={r2} r3={r3} r4={r4} r5={r5}");
            Console.WriteLine($"Сокращённые дроби: r1={r1.Simplify()} r2={r2.Simplify()} r3={r3.Simplify()} r4={r4.Simplify()} r5={r5.Simplify()}");
            Console.WriteLine($"Обратные дроби: r1={r1.Reverse()} r2={r2.Reverse()} r3={r3.Reverse()} r4={r4.Reverse()} r5={r5.Reverse()}");
            Console.WriteLine($"r1={r1} r2={r2} r3={r3} r4={r4} r5={r5}");

            Console.WriteLine($"r1*r2={r1* r2}");
            Console.WriteLine($"r1*3={r1 * new Ratio(3)}");
            Console.WriteLine($"r3*r5={r3 * r5}");
            Console.WriteLine($"r2.Multiply(r4)={r2.Multiply(r4)}");

            Console.WriteLine($"r4/r2={r4 / r2}");
            Console.WriteLine($"r3.Divide(r4)={r3.Divide(r4)}");

            Console.WriteLine($"r1-r2={r1 - r2}");
            Console.WriteLine($"r1-3={r1 - new Ratio(3)}");
            Console.WriteLine($"r3-r3={r3 - r3}");
            Console.WriteLine($"r2.Subtract(r4)={r2.Subtract(r4)}");

            Console.WriteLine($"r1+r2={r1 + r2}");
            Console.WriteLine($"r1+3={r1 + new Ratio(3)}");
            Console.WriteLine($"r5+r3={r5 + r3}");
            Console.WriteLine($"r2.Plus(r4)={r2.Plus(r4)}");


            Console.ReadKey();
            
        }
    }
}
