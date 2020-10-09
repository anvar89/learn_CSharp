using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
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

        }
    }
 
    
}
