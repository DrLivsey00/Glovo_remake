namespace Glovo.forms
{
    partial class LogIn_for_admins
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
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F);
            button1.Location = new Point(179, 157);
            button1.Name = "button1";
            button1.Size = new Size(100, 24);
            button1.TabIndex = 10;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(159, 103);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(189, 23);
            textBox1.TabIndex = 9;
            // 
            // email_input
            // 
            email_input.Location = new Point(159, 70);
            email_input.Name = "email_input";
            email_input.Size = new Size(189, 23);
            email_input.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(90, 103);
            label2.Name = "label2";
            label2.Size = new Size(67, 17);
            label2.TabIndex = 7;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(90, 73);
            label1.Name = "label1";
            label1.Size = new Size(42, 17);
            label1.TabIndex = 6;
            label1.Text = "Email:";
            // 
            // LogIn_for_admins
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 213);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(email_input);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LogIn_for_admins";
            Text = "Admin login";
            FormClosed += LogIn_for_admins_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox email_input;
        private Label label2;
        private Label label1;
    }
}