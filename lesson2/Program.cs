using System;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;

namespace lesson2
{
    class Program
    {
        // Курс "Основы языка С#", урок №2
        // Выполнил Халитов А. Р.

        static void Main(string[] args)
        {
            string login, password;
            double height, weight, bmi, exceedWeight;
            int tryCount = 0;
            bool authorized;

            //Проверка задачи 1
            Console.WriteLine(Min(100,200,300));
            //Проверка задачи 2
            Console.WriteLine(DigitCounter(-123));
            //Проверка задачи 3
            SumOfOddNum();
            //Задача 4
            Console.WriteLine("Программа авторизации пользователя.");
            do
            {
                Console.Write("Введите логин: ");
                login = Console.ReadLine();

                Console.Write("Введите пароль: ");
                password = Console.ReadLine();

                Authorization(login, password, out authorized);
                if (authorized) break;
                else tryCount++;

            } while (tryCount <3);

            if (authorized) Console.WriteLine("Вы авторизованы!");
            else Console.WriteLine("Попытки входа исчерпаны!");

            // Задача 5 - ИМТ
            Console.Write("Ваш рост (м): ");
            height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ваш вес (кг): ");
            weight = Convert.ToDouble(Console.ReadLine());

            bmi = BodyMassIndex(height, weight, out exceedWeight);

            Console.WriteLine($"Ваш ИМТ = {bmi:f2}. ");
            if (bmi < 25.0) Console.Write($"Вам следует набрать {exceedWeight:f2} кг");
            else if (bmi > 30.0) Console.Write($"Вам следует похудеть на {exceedWeight:f2} кг");
            else Console.Write($"У вас нормальный вес!");

            // Задача 6 - число хороших чисел
            DateTime dt1 = DateTime.UtcNow;
            int GoodNumCount = 0;
            for (int i = 1; i <= 1000000000; i++)
            {
                if (IsGood(i)) GoodNumCount++;
            }
            DateTime dt2 = DateTime.UtcNow;
            Console.WriteLine($"количества хороших чисел: {GoodNumCount}");
            Console.WriteLine($"Потрачено времени: {dt2.Subtract(dt1)}");

            // Задача 7А - рекурсивмный метод, выводящий чмсла от А до B
            RecPrintAB(1, 20);
            // Задача 7Б - рекурсивный метод, суммирующий числа от А до B
            Console.WriteLine("Сумма чисел от 1 до 10 : " + RecSumAB(1, 10));

        }

        #region Задача 1 - найти минимальное число из трёх
        static int Min(int num1, int num2, int num3)
        {
            int tmp = (num1 < num2) ? num1 : num2;
            if (tmp < num3) return tmp;
            return num3;
        }
        #endregion

        #region Задача 2 - подсчёт количества цифр числа
        static int DigitCounter(int num)
        {
            int cnt = 0;
            string s = Convert.ToString(num);
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s, i)) cnt++;
            }
            return cnt;

        }
        #endregion

        #region Задача 3 - сумма введнных нечётных чисел
        static void SumOfOddNum()
        {
            int tmp, sum = 0;
            while (true)
            {
                Console.Write("Введите число: ");
                string s = Console.ReadLine();

                if (s.Equals("0")) break;

                if (Int32.TryParse(s, out tmp))
                {
                    if (tmp % 2 != 0) sum += tmp;
                }
                else Console.WriteLine("нужно было ввести число");

            }
            Console.WriteLine($"Сумма нечётных числел : {sum}");
        }

        #endregion

        #region Задача 4 -  метод реализующий авторизацию
        static void Authorization(string login, string password, out bool authorized)
        {
            authorized = login.Equals("root") && password.Equals("GeekBrains");
        }
        #endregion

        #region Задача 5 - метод, вычисляющий ИМТ и избыточный/недостающий вес
        static double BodyMassIndex(double height, double weight, out double excessWeight)
        {
            double bmi = weight / height / height;
            if (bmi > 30.0) excessWeight = weight - 30.0 * height * height;
            else if (bmi < 25.0) excessWeight = 25.0 * height * height - weight;
            else excessWeight = 0.0;
            return bmi;
        }
        #endregion

        #region Задача 6 - метод, определяющий "хорошее" ли число
        static bool IsGood(int number)
        {
            int n, digit, sumOfDigit = 0;
            n = number;
            while (n > 0)
            {
                digit = n % 10;
                sumOfDigit += digit;
                n /= 10;
            }
            return(number % sumOfDigit == 0); 
        }
        #endregion

        #region Задача 7а - рекурсивный метод, выводящий числа от А до В
        static void RecPrintAB(int a, int b)
        {
            if (a <= b)
            {
                Console.Write($"{a} ");
                RecPrintAB(++a, b);
            }
            else Console.WriteLine();
        }
        #endregion

        #region Задача 7б - рекурсивный метод, суммирующий числа от А до В
        static int RecSumAB(int a, int b)
        {
            if (a <= b)
            {
                return b + RecSumAB(a, --b);
            }
            else return 0;
        }
        #endregion
    }


}
