namespace GeekBrain_Lesson7
{
    partial class Task2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnStartSurrend = new System.Windows.Forms.Button();
            this.lblTryCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPlayerInput = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.Location = new System.Drawing.Point(12, 141);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(330, 25);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Нажмите \"Играть\", чтобы начать!";
            // 
            // btnStartSurrend
            // 
            this.btnStartSurrend.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnStartSurrend.Location = new System.Drawing.Point(31, 69);
            this.btnStartSurrend.Name = "btnStartSurrend";
            this.btnStartSurrend.Size = new System.Drawing.Size(195, 50);
            this.btnStartSurrend.TabIndex = 4;
            this.btnStartSurrend.Text = "Играть!";
            this.btnStartSurrend.UseVisualStyleBackColor = true;
            this.btnStartSurrend.Click += new System.EventHandler(this.btnStartSurrend_Click);
            // 
            // lblTryCount
            // 
            this.lblTryCount.AutoSize = true;
            this.lblTryCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTryCount.Location = new System.Drawing.Point(175, 175);
            this.lblTryCount.Name = "lblTryCount";
            this.lblTryCount.Size = new System.Drawing.Size(19, 21);
            this.lblTryCount.TabIndex = 7;
            this.lblTryCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-1, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Количество попыток:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ваш вариант:";
            // 
            // tbxPlayerInput
            // 
            this.tbxPlayerInput.Enabled = false;
            this.tbxPlayerInput.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbxPlayerInput.Location = new System.Drawing.Point(167, 9);
            this.tbxPlayerInput.Name = "tbxPlayerInput";
            this.tbxPlayerInput.Size = new System.Drawing.Size(81, 33);
            this.tbxPlayerInput.TabIndex = 2;
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCheck.Location = new System.Drawing.Point(255, 9);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(125, 33);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "Проверить";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 195);
            this.Controls.Add(this.lblTryCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartSurrend);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.tbxPlayerInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInfo);
            this.Name = "Task2";
            this.Text = "Игра \"Угадай число\"";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnStartSurrend;
        private System.Windows.Forms.Label lblTryCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxPlayerInput;
        private System.Windows.Forms.Button btnCheck;
    }
}