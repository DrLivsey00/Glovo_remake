namespace Glovo.forms
{
    partial class Log_In
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
            label1 = new Label();
            label2 = new Label();
            email_input = new TextBox();
            textBox1 = new TextBox();
            log_up = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 70);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(113, 100);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // email_input
            // 
            email_input.Location = new Point(182, 67);
            email_input.Name = "email_input";
            email_input.Size = new Size(189, 23);
            email_input.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(182, 100);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(189, 23);
            textBox1.TabIndex = 3;
            // 
            // log_up
            // 
            log_up.AutoSize = true;
            log_up.ForeColor = SystemColors.MenuHighlight;
            log_up.Location = new Point(182, 135);
            log_up.Name = "log_up";
            log_up.Size = new Size(146, 15);
            log_up.TabIndex = 4;
            log_up.Text = "Not registered yet? Log up";
            log_up.Click += log_up_Click;
            // 
            // button1
            // 
            button1.Location = new Point(211, 158);
            button1.Name = "button1";
            button1.Size = new Size(100, 24);
            button1.TabIndex = 5;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Log_In
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 243);
            Controls.Add(button1);
            Controls.Add(log_up);
            Controls.Add(textBox1);
            Controls.Add(email_input);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Log_In";
            Text = "Log_In";
            FormClosed += Log_In_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox email_input;
        private TextBox textBox1;
        private Label log_up;
        private Button button1;
    }
}