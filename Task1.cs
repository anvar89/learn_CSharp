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
    public partial class Task1 : Form
    {
        Stack<string> Operations = new Stack<string>();
        int gain;

        public Task1()
        {
            InitializeComponent();

            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Сброс";
            lblNumber.Text = "1";

            
        }

        private void CheckResult(int number)
        {
            if (number == gain)
            {
                btnCommand1.Enabled = false;
                btnCommand2.Enabled = false;
                btnReset.Enabled = false;
                btnUndo.Enabled = false;
                btnStart.Enabled = true;

                lblWin.Visible = true;
            }
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            int tmp = int.Parse(lblNumber.Text) + 1;
            lblNumber.Text = tmp.ToString();

            lblTryCount.Text = (int.Parse(lblTryCount.Text) + 1).ToString(); // Увеличиваем количество использованных попыток
            Operations.Push("+1"); // фиксируем действие
            CheckResult(tmp);
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            int tmp = int.Parse(lblNumber.Text) * 2;
            lblNumber.Text = tmp.ToString();

            lblTryCount.Text = (int.Parse(lblTryCount.Text) + 1).ToString(); // Увеличиваем количество использованных попыток
            Operations.Push("x2");
            CheckResult(tmp);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnCommand1.Enabled = false;
            btnCommand2.Enabled = false;
            btnReset.Enabled = false;
            btnUndo.Enabled = false;
            btnStart.Enabled = true;
            lblWin.Visible = false;

            lblNumber.Text = "1";
            lblTryCount.Text = "0";
            Operations.Clear();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (Operations.Count > 0)
            {
                string s = Operations.Pop();

                switch (s)
                {
                    case "+1":
                        lblNumber.Text = (int.Parse(lblNumber.Text) - 1).ToString();
                        break;
                    case "x2":
                        lblNumber.Text = (int.Parse(lblNumber.Text) / 2).ToString();
                        break;
                }
                lblTryCount.Text = (int.Parse(lblTryCount.Text) + 1).ToString(); // Увеличиваем количество использованных попыток
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnCommand1.Enabled = true;
            btnCommand2.Enabled = true;
            btnUndo.Enabled = true;
            btnReset.Enabled = true;
            btnStart.Enabled = false;
            lblWin.Visible = false;

            Random rnd = new Random();
            gain = rnd.Next(1000);
            lblGain.Text = gain.ToString();

        }
    }
}
