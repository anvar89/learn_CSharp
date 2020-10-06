using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;

namespace lesson4
{
    class Program
    {
        // Курс "Основы языка С#", урок №4
        // Выполнил Халитов А. Р.

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] array = new int[20];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-10000, 10000);
            }
            // Проверка задачи 1, 2а
            Console.WriteLine("Задача 1, 2а");
            Console.WriteLine("Исседуемый массив");
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Результат: {StaticClass.CountPairs(array)}");


            Console.WriteLine("Задача 2б - метод чтения массива из файла");
            int[] arr = StaticClass.ReadArrFromFile(@"C:\learn_CSharp\array.txt");

            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine("Задача 2в - Нет файла");
            int[] arr2 = StaticClass.ReadArrFromFile(@"C:\learn_CSharp\array2222.txt");

        }

    }

    static class StaticClass
    {
        public static int CountPairs(int[] arr)
        {
            int cnt = 0;
            for (int i = 0; i < (arr.Length - 1); i++)
            {
                if ((arr[i] % 3 == 0) ^ (arr[i + 1] % 3 == 0)) cnt++;
            }
            return cnt;
        }
        
        public static int[] ReadArrFromFile(string path)
        {       
            try
            {
                StreamReader sr = new StreamReader(path);
                String[] strArr = (sr.ReadLine()).Split(" ");
                int[] result = new int[strArr.Length];

                for (int i = 0; i < strArr.Length; i++)
                {
                    if (!Int32.TryParse(strArr[i], out result[i])) result[i] = 0;
                }
                return result;
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Файл не найден");
                return null;
            }
        }
    }
 
    
}
