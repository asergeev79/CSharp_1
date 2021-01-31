using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01_b
{
    class Complex
    {

        #region Private Fields

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        private double im;

        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        private double re;

        #endregion

        #region Public Properties
        public double Im
        {
            get
            {
                return im;
            }

            set
            {
                im = value;
            }
        }

        public double Re
        {
            get
            {
                return re;
            }

            set
            {
                re = value;
            }
        }
        #endregion

        #region Constructors
        public Complex()
        {
        }

        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        #endregion

        #region Public Methods
        public Complex Plus(Complex x)
        {
            return new Complex(re + x.Re, im + x.Im);
        }
        public static Complex operator +(Complex complex1, Complex complex2)
        {
            return new Complex { Re = complex1.Re + complex2.Re, Im = complex1.Im + complex2.Im };
        }

        public Complex Subtract(Complex x)
        {
            return new Complex(re - x.Re, im - x.Im);
        }
        public static Complex operator -(Complex complex1, Complex complex2)
        {
            return new Complex { Re = complex1.Re - complex2.Re, Im = complex1.Im - complex2.Im };
        }

        public Complex Multiply(Complex x)
        {
            return new Complex((re * x.Re - im * x.Im), (re * x.Im + im * x.Re));
        }
        public static Complex operator *(Complex complex1, Complex complex2)
        {
            return new Complex { Re = (complex1.Re * complex2.Re - complex1.Im * complex2.Im), Im = (complex1.Re * complex2.Im + complex1.Im * complex2.Re)};
        }

        public override string ToString()
        {
            return (im > 0) ? $"{re} + {im}i" : $"{re} + ({im})i";
        }

        #endregion

    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex complex1 = new Complex();
            complex1.Im = 12;
            complex1.Re = -3;

            Complex complex2 = new Complex(-1, 5);

            Console.WriteLine($"Результат сложения комплексных чисел {complex1} и {complex2} -> {complex1.Plus(complex2)}");
            Console.WriteLine($"Результат сложения комплексных чисел {complex1} и {complex2} с использованием оператора -> {complex1 + complex2}");
            Console.WriteLine($"Результат разности комплексных чисел {complex1} и {complex2} -> {complex1.Subtract(complex2)}");
            Console.WriteLine($"Результат разности комплексных чисел {complex1} и {complex2} с использованием оператора -> {complex1 - complex2}");
            Console.WriteLine($"Результат произведения комплексных чисел {complex1} и {complex2} -> {complex1.Multiply(complex2)}");
            Console.WriteLine($"Результат произведения комплексных чисел {complex1} и {complex2} с использованием оператора -> {complex1 * complex2}");
            Console.ReadKey();

        }
    }
}
