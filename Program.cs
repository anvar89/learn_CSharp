using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace lesson6
{


    class Program
    {
        // Курс "Основы языка С#", урок №6
        // Выполнил Халитов А. Р.

        // Задача 1 - Доработка метода, выводящего таблицу
        delegate double Fun(double x, double a);

        static void Table(Fun Func, double startInterval, double endInterval, double step)
        {
            double x = startInterval;
            double a = startInterval;

            Console.WriteLine("----- X -------- A -------- Y --");
            while (x <= endInterval)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000}", x, a, Func(x, a));
                x += step;
                a += step;
            }
            Console.WriteLine("--------------------------------");

        }

        static double Func1(double x, double a)
        {
            return a * x * x;
        }

        static double Func2(double x, double a)
        {
            return a * Math.Sin(x);
        }

        // Задача 2 - доработка программы нахождения min
        public delegate double FuncTask2(double arg);

        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return -30 * x * x + 10;
        }

        public static double F3(double x)
        {
            return 30 * Math.Sin(0.1 * x) + 3;
        }

        public static double F4(double x)
        {
            return x * x * x - 50 * x + 10;
        }


        public static void SaveFunc(string fileName, FuncTask2 F, double startInterval, double endInterval, double step)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = startInterval;
            while (x <= endInterval)
            {
                bw.Write(F(x));
                x += step;
            }
            bw.Close();
            fs.Close();
        }
        
        public static List<double> Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            List<double> result = new List<double>();

            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
                result.Add(d);
            }
            bw.Close();
            fs.Close();

            return result;
        }


        static void Main(string[] args)
        {
            // Задача 1 - демонстрация
            Table(Func1, 0, 10, 1);
            Table(Func2, 0, 10, 1);

            // Задача 2 - демонстрация и реализация меню
            bool correctChoose = false;
            int funcNum;
            double startInterval, endInterval, min;
            List<FuncTask2> funcs = new List<FuncTask2>() { F1, F2, F3, F4 };

            Console.WriteLine("Задача 2. Доработка программы нахождения минимума функции на заданном интервале.");
            Console.WriteLine("Выберите функцию:");
            Console.WriteLine("1. f(x) = x^2 - 50x + 10");
            Console.WriteLine("2. f(x) = 10 - 30x^2");
            Console.WriteLine("3. f(x) = 30Sin(x / 10) + 3");
            Console.WriteLine("4. f(x) = x^3 - 50x + 10");
            Console.Write("Укажите номер функции: ");
            do
            {
                if (!Int32.TryParse(Console.ReadLine(), out funcNum)) 
                    Console.WriteLine("Нужно ввести число от 1 до 4");
                else
                {
                    if ((funcNum >= 1) && (funcNum <= 4)) correctChoose = true;
                    else Console.WriteLine("Нужно ввести число от 1 до 4");
                }
            } while (!correctChoose);

            Console.Write("Укажите интервал. Начало: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out startInterval)) break;
                else Console.WriteLine("Введите корректное число");
            }

            Console.Write("Конец интервала: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out endInterval)) 
                {
                    if (endInterval <= startInterval) Console.WriteLine($"Введите число, большее чем {startInterval:f2}");
                    else break;
                }
                else Console.WriteLine("Введите корректное число");
            }

            string fileName = "data.bin";
            SaveFunc(fileName, funcs[funcNum], startInterval, endInterval, 0.5);
            List<double> result = Load(fileName, out min);
            Console.WriteLine($"Минимум функции на заданном интервале от {startInterval:f2} до {endInterval:f2} равен {min:f2}");
        }
    }
}
