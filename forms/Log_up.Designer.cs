﻿namespace Glovo.forms
{
    partial class Log_up
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
            button1 = new Button();
            textBox1 = new TextBox();
            email_input = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F);
            button1.Location = new Point(186, 129);
            button1.Name = "button1";
            button1.Size = new Size(100, 24);
            button1.TabIndex = 11;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(164, 90);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(189, 23);
            textBox1.TabIndex = 9;
            // 
            // email_input
            // 
            email_input.Location = new Point(164, 57);
            email_input.Name = "email_input";
            email_input.Size = new Size(189, 23);
            email_input.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(95, 90);
            label2.Name = "label2";
            label2.Size = new Size(67, 17);
            label2.TabIndex = 7;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(95, 60);
            label3.Name = "label3";
            label3.Size = new Size(42, 17);
            label3.TabIndex = 6;
            label3.Text = "Email:";
            // 
            // Log_up
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 181);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(email_input);
            Controls.Add(label2);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Log_up";
            Text = "Log_up";
            FormClosed += Log_up_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox email_input;
        private Label label2;
        private Label label3;
    }
}