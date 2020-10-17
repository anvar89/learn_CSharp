using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekBrain_Lesson7
{
    //  Домашнее задание к уроку №7
    //  курс "Основы языка C#"
    //  Выполнил Халитов А. Р.
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Task1()); // Игра УДВОИТЕЛЬ
            Application.Run(new Task2()); // Игра УГАДАЙКА
        }
    }
}
