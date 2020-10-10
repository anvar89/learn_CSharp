using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;

namespace lesson5
{
    class Program
    {
        // Курс "Основы языка С#", урок №5
        // Выполнил Халитов А. Р.

        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1 - проверка логина с помощью регулярных выражений");
            Console.Write("Введите логин:");
            String login = Console.ReadLine();

            Console.WriteLine("А - Проверка логина методом с использованием регулярный выражений");
            if (Task1.IsCorrect(login)) Console.WriteLine("Логин корректен!");
            else Console.WriteLine("Логин не корректен!");

            Console.WriteLine("Б - Проверка логина методом без использования регулярных выражений");
            if (Task1.IsCorrectAlt(login)) Console.WriteLine("Логин корректен!");
            else Console.WriteLine("Логин не корректен!");


            Console.WriteLine("Задача 2 - класс Message со статическими методами");

            StreamReader sr = new StreamReader(@"C:\learn_CSharp\Program.cs");

            string program = string.Empty;
            string line;
            while((line = sr.ReadLine()) != null)
            {
                program += line;
            }

            Console.WriteLine("Метод, удаляющий из сообщения все слова больше указанной длины");
            Console.WriteLine(Message.OnlyShortWords(program, 10));
            //Console.WriteLine("Метод, удаляющий все слова, заканчивающиеся на указанную букву");
            //Console.WriteLine(Message.DeleteWordsEndWith(program, "S")); // Выдаёт слишком длинную строку
            Console.WriteLine("Метод, возвращающий самое длинное слово");
            Console.WriteLine(Message.MaxLengthWord(program));
            Console.WriteLine("Метод, возвращающий указанное число самых длинных слов");
            Console.WriteLine(Message.MaxLengthWords(program, 3));
        }
        static class Task1
        {
            public static bool IsCorrect(string login)
            {
                Regex regex = new Regex(@"((^\D{1})([a-zA-Z0-9]{1,9})){1,10}$", RegexOptions.IgnoreCase);
                return regex.IsMatch(login);
            }

            public static bool IsCorrectAlt(string login)
            {
                login = login.ToLower();
                if ((login.Length > 1) && (login.Length < 11))
                {
                    if (char.IsLetter(login[0]))
                    {
                        for (int i = 1; i < login.Length; i++)
                        {
                            if (!char.IsLetterOrDigit(login[i])) return false;
                        }
                        return true;
                    }
                }
                return false;
            }
        }

        static class Message
        {
            public static string OnlyShortWords(string message, int limit)
            {
                string pattern = @"^\w{1," + limit + "}$";
                Regex regex = new Regex(pattern);
                string[] words = Regex.Split(message, @"\s+");
                string result = string.Empty;

                for (int i = 0; i < words.Length; i++)
                {
                    if (regex.IsMatch(words[i])) result = result + " " + words[i];
                }
                
                return result.Trim();
            }

            public static string DeleteWordsEndWith(string message, string letter)
            {
                string pattern = @"\s*\w*" + letter + @"\b";
                return Regex.Replace(message, pattern, string.Empty);
            }

            public static string MaxLengthWord(string message)
            {
                string[] arr = message.Split(" ");
                int tmp = 0;
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i].Length > arr[tmp].Length) tmp = i;
                }

                return arr[tmp];
            }

            public static string MaxLengthWords(string message, int n)
            {
                StringBuilder sb = new StringBuilder();
                string[] arr = message.Split();
                string tmp;
                int[] IntArr = new int[n];
                
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i].Length > arr[j].Length)
                        {
                            tmp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = tmp;
                        }
                    }
                }
                //foreach (var item in arr)
                //{
                //    sb.Append(item);
                //    sb.Append(" ");
                //}

                for (int i = 0; i < n; i++)
                {
                    sb.Append(arr[arr.Length - 1 - i]); 
                    sb.Append(" ");
                }

                return sb.ToString();
            }
        }

    }
 
    
}
