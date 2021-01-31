using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    struct Complex
        {
            /// <summary>
            /// Мнимая часть комплексного числа
            /// </summary>
            public double im;

            /// <summary>
            /// Действительная часть комплексного числа
            /// </summary>
            public double re;

            public Complex Plus(Complex x)
            {
                Complex y;
                y.im = im + x.im;
                y.re = re + x.re;
                return y;
            }

            public Complex Subtract(Complex x)
            {
                Complex y;
                y.im = im - x.im;
                y.re = re - x.re;
                return y;
            }
            public Complex Multiply(Complex x)
            {
                Complex y;
                y.im = (re * x.im) + (im * x.re);
                y.re = (re * x.re) - (im * x.im);
                return y;
            }

            public override string ToString()
            {
                return (im > 0) ? $"{re} + {im}i" : $"{re} + ({im})i";
            }

        }
    class Program
    {
        static void Main(string[] args)
        {
            Complex complex1;
            complex1.re = 12;
            complex1.im = -3;

            Complex complex2;
            complex2.re = -1;
            complex2.im = 5;

            Console.WriteLine($"Результат сложения комплексных чисел {complex1} и {complex2} -> {complex1.Plus(complex2)}");
            Console.WriteLine($"Результат разности комплексных чисел {complex1} и {complex2} -> {complex1.Subtract(complex2)}");
            Console.WriteLine($"Результат произведения комплексных чисел {complex1} и {complex2} -> {complex1.Multiply(complex2)}");

            Console.ReadKey();

        }
    }
}
