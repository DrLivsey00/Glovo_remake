namespace Glovo.forms
{
    partial class Admin
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
            admin_label = new Label();
            total_orders_label = new Label();
            total_orders_users = new Label();
            total_profit_label = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // admin_label
            // 
            admin_label.AutoSize = true;
            admin_label.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            admin_label.ForeColor = Color.Red;
            admin_label.Location = new Point(261, 9);
            admin_label.Name = "admin_label";
            admin_label.Size = new Size(138, 30);
            admin_label.TabIndex = 0;
            admin_label.Text = "Admin Panel";
            // 
            // total_orders_label
            // 
            total_orders_label.AutoSize = true;
            total_orders_label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            total_orders_label.Location = new Point(51, 114);
            total_orders_label.Name = "total_orders_label";
            total_orders_label.Size = new Size(103, 20);
            total_orders_label.TabIndex = 1;
            total_orders_label.Text = "Total orders: 0";
            // 
            // total_orders_users
            // 
            total_orders_users.AutoSize = true;
            total_orders_users.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            total_orders_users.Location = new Point(51, 153);
            total_orders_users.Name = "total_orders_users";
            total_orders_users.Size = new Size(94, 20);
            total_orders_users.TabIndex = 2;
            total_orders_users.Text = "Total users: 0";
            // 
            // total_profit_label
            // 
            total_profit_label.AutoSize = true;
            total_profit_label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            total_profit_label.Location = new Point(51, 199);
            total_profit_label.Name = "total_profit_label";
            total_profit_label.Size = new Size(98, 20);
            total_profit_label.TabIndex = 3;
            total_profit_label.Text = "Total profit: 0";
            // 
            // button1
            // 
            button1.Location = new Point(308, 114);
            button1.Name = "button1";
            button1.Size = new Size(274, 36);
            button1.TabIndex = 4;
            button1.Text = "Manage menu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(308, 183);
            button2.Name = "button2";
            button2.Size = new Size(274, 36);
            button2.TabIndex = 5;
            button2.Text = "Manage orders";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 292);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(total_profit_label);
            Controls.Add(total_orders_users);
            Controls.Add(total_orders_label);
            Controls.Add(admin_label);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Admin";
            Text = "Admin";
            FormClosed += Admin_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label admin_label;
        private Label total_orders_label;
        private Label total_orders_users;
        private Label total_profit_label;
        private Button button1;
        private Button button2;
    }
}