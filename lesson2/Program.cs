using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;

namespace lesson3
{
    class Program
    {
        // Курс "Основы языка С#", урок №3
        // Выполнил Халитов А. Р.

        static void Main(string[] args)
        {
            // Задача 1а - метод вычитания для структуры "Комплексное число"
            Console.WriteLine("Задача 1а. Проверка структуры \"Комплексное число\"");
            ComplexNumber x = new ComplexNumber(10.0, 20.0);
            ComplexNumber y = new ComplexNumber(11.0, 22.0);
            ComplexNumber result = y.Subtract(x);
            Console.WriteLine($"Разность комплексных чисел {y} и {x} равна: {result}");

            // Задача 1б - методы вычитания и умножение класса комплексных чисел
            Console.WriteLine("Задача 1б. Проверка класса \"Комплексное число\"");
            Complex x1 = new Complex(100.0, 200.0);
            Complex y1 = new Complex(101.0, 202.0);
            Complex result1 = y1.Subtract(x1);
            Complex result2 = y1.Multi(x1);
            Console.WriteLine($"Разность комплексных чисел {y1} и {x1} равна: {result1}");
            Console.WriteLine($"Произведение комплексных чисел {y1} и {x1} равна: {result2}");

            // Проверка задачи 3 - класс дробь
            Fraction fr1 = new Fraction(1, 2);
            Fraction fr2 = new Fraction(3, 4);

            Console.WriteLine("Задача 3. Проверка класс дроби");
            Console.WriteLine($"Сложение : {fr1} + {fr2} = {fr1.Add(fr2)}");
            Console.WriteLine($"Сложение : {fr1} - {fr2} = {fr1.Subtract(fr2)}");
            Console.WriteLine($"Сложение : {fr1} * {fr2} = {fr1.Multi(fr2)}");
            Console.WriteLine($"Сложение : {fr1} / {fr2} = {fr1.Divide(fr2)}");

            // Задача 2 - подсчёт суммы нечётных чисел
            Console.WriteLine("Задача 2 - посчёт суммы нечётных чисел");
            List<int> oddNumbers = new List<int>();
            int summ = 0;
            int number;

            while (true)
            {
                Console.Write("Введите целое число: ");
                string userInput = Console.ReadLine();

                if (userInput.Equals("0")) break;

                if (Int32.TryParse(userInput, out number))
                {
                    if ((number > 0) && (number % 2 != 0))
                    {
                        oddNumbers.Add(number);
                        summ += number;
                    }
                }
                else
                {
                    Console.WriteLine("Нужно бы ввести число");
                }

            }
            Console.WriteLine($"Сумма нечётных положительный чисел: {summ}");
            foreach (var item in oddNumbers)
            {
                Console.Write(item + " ");
            }
        }

    }
    // Задача 1б. Доработка класса "Комплексное число"
    class Complex
    {
        public double im;
        public double re;

        public Complex(double im, double re)
        {
            this.im = im;
            this.re = re;
        }

        public Complex()
        {
            im = 0;
            re = 0;
        }

        public Complex Plus(Complex x)
        {
            Complex result = new Complex();
            result.re = re + x.re;
            result.im = im + x.im;

            return result;
        }
        public Complex Multi(Complex x)
        {
            Complex result = new Complex();
            result.re = re * x.re - im * x.im;
            result.im = im * x.re + re * x.im;

            return result;
        }
        public Complex Subtract(Complex x)
        {
            Complex result = new Complex();
            result.re = re - x.re;
            result.im = im - x.im;

            return result;
        }

        public override string ToString()
        {
            return re + "+" + im + "i";
        }
    }

    // Задача 1а. доработка структуры "Комплексное число"
    struct ComplexNumber
    {
        public double im;
        public double re;

        public ComplexNumber(double im, double re)
        {
            this.im = im;
            this.re = re;
        }
        //  в C# в структурах могут храниться также действия над данными
        public ComplexNumber Plus(ComplexNumber x)
        {
            ComplexNumber y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }
        //  Пример произведения двух комплексных чисел
        public ComplexNumber Multi(ComplexNumber x)
        {
            ComplexNumber y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public ComplexNumber Subtract(ComplexNumber x)
        {
            ComplexNumber y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        public override string ToString()
        {
            return re + "+" + im + "i";
        }
    }

    //Задача 3 - класс дробь
    class Fraction
    {
        int num;
        int denom;

        public Fraction(int num, int denom)
        {
            if (denom == 0) throw new ArgumentException("Знаменатель не может быть равен 0");
            this.num = num;
            this.denom = denom;
        }

        public Fraction Add(Fraction x)
        {
            Fraction result = new Fraction(x.denom * num + denom * x.num, denom * x.denom);
            result.Simplify();
            return result;
        }

        public Fraction Subtract(Fraction x)
        {
            Fraction result = new Fraction(x.denom * num - denom * x.num, denom * x.denom); ;
            result.Simplify();
            return result;

        }

        public Fraction Multi(Fraction x)
        {
            Fraction result = new Fraction(num * x.num, denom * x.denom);
            result.Simplify();
            return result;
        }

        public Fraction Divide(Fraction x)
        {
            Fraction result = new Fraction(num * x.denom, denom * x.num);
            result.Simplify();
            return result;
        }

        public double ToDouble
        {
            get
            {
                return (double)num / denom;
            }
        }

        public void Simplify()
        {
            for (int i = denom / 2; i > 1; i--)
            {
                if ((denom % i == 0) && (num % i == 0))
                {
                    denom /= i;
                    num /= i;
                }
            }
        }

        public override string ToString()
        {
            return num + "/" + denom;
        }
    }
    
}
