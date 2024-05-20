namespace Glovo.forms
{
    partial class Cart
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
            btn_proceed = new Button();
            btn_back = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_proceed
            // 
            btn_proceed.AutoSize = true;
            btn_proceed.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_proceed.Font = new Font("Segoe UI", 9.75F);
            btn_proceed.Location = new Point(327, 85);
            btn_proceed.Name = "btn_proceed";
            btn_proceed.Size = new Size(58, 27);
            btn_proceed.TabIndex = 0;
            btn_proceed.Text = "Submit";
            btn_proceed.UseVisualStyleBackColor = true;
            btn_proceed.Click += btn_proceed_Click;
            // 
            // btn_back
            // 
            btn_back.AutoSize = true;
            btn_back.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_back.Font = new Font("Segoe UI", 9.75F);
            btn_back.Location = new Point(86, 85);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(44, 27);
            btn_back.TabIndex = 1;
            btn_back.Text = "Back";
            btn_back.UseVisualStyleBackColor = true;
            btn_back.Click += btn_back_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(207, 9);
            label1.Name = "label1";
            label1.Size = new Size(61, 17);
            label1.TabIndex = 2;
            label1.Text = "Корзина";
            // 
            // Cart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(461, 124);
            Controls.Add(label1);
            Controls.Add(btn_back);
            Controls.Add(btn_proceed);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Cart";
            Text = "Cart";
            FormClosed += Cart_FormClosed;
            Load += Cart_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_proceed;
        private Button btn_back;
        private Label label1;
    }
}