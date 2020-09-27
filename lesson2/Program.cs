using System;

namespace lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Min(100,200,300));
        }

        #region Задача 1 - найти минимальное число из трёх
        static int Min(int num1, int num2, int num3)
        {
            int tmp = (num1 < num2) ? num1 : num2;
            if (tmp < num3) return tmp;
            return num3;
        }
        #endregion
    }


}
