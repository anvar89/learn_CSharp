using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekBrain_Lesson7
{
    public partial class Task2 : Form
    {
        bool gameProcessing = false; // true - игра запущена, игрок должен отгадать число. 
        int number, playerAnswer;


        public Task2()
        {
            InitializeComponent();
        }

        private void RestartGame()
        {
            gameProcessing = false;

            btnStartSurrend.Text = "Играть!";
            tbxPlayerInput.Enabled = false;
            btnCheck.Enabled = false;
        }

        private void btnStartSurrend_Click(object sender, EventArgs e)
        {
            // Если игра запущена - останавливаем, не запущане - закускаем
            if (gameProcessing)
            {
                RestartGame();
                lblInfo.Text = "Нажмите \"Играть\", чтобы начать!";
                lblTryCount.Text = "0";
                tbxPlayerInput.Text = string.Empty;
            }
            else
            {
                gameProcessing = true;

                btnStartSurrend.Text = "Сдаться..";
                tbxPlayerInput.Enabled = true;
                btnCheck.Enabled = true;
                lblInfo.Text = "Введите число 0 до 100";

                Random rnd = new Random();
                number = rnd.Next(0, 100);
            }


        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbxPlayerInput.Text, out playerAnswer))
            {
                if (playerAnswer > number) lblInfo.Text = $"{playerAnswer} - это слишком большое число!";
                if (playerAnswer < number) lblInfo.Text = $"{playerAnswer} - это слишком маленькое число!";
                if (playerAnswer == number)
                {
                    RestartGame();
                    lblInfo.Text = "Правильный ответ! Ещё раз?";
                }

                tbxPlayerInput.Text = string.Empty;

                lblTryCount.Text = (int.Parse(lblTryCount.Text) + 1).ToString();
            }
        }
    }
}
