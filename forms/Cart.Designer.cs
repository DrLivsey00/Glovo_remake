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
            SuspendLayout();
            // 
            // btn_proceed
            // 
            btn_proceed.Location = new Point(310, 536);
            btn_proceed.Name = "btn_proceed";
            btn_proceed.Size = new Size(131, 28);
            btn_proceed.TabIndex = 0;
            btn_proceed.Text = "Submit";
            btn_proceed.UseVisualStyleBackColor = true;
            btn_proceed.Click += btn_proceed_Click;
            // 
            // btn_back
            // 
            btn_back.Location = new Point(12, 536);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(131, 28);
            btn_back.TabIndex = 1;
            btn_back.Text = "Back";
            btn_back.UseVisualStyleBackColor = true;
            btn_back.Click += btn_back_Click;
            // 
            // Cart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 591);
            Controls.Add(btn_back);
            Controls.Add(btn_proceed);
            Name = "Cart";
            Text = "Cart";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_proceed;
        private Button btn_back;
    }
}