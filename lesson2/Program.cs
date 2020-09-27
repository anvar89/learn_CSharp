using System;
using System.Net.Mail;

namespace lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Min(100,200,300));
            //Console.WriteLine(DigitCounter(-123));
            SumOfOddNum();
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
    }


}
