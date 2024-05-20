using Glovo.internal_pkg.models;
using Glovo.internal_pkg.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Glovo.forms
{

    public partial class LogIn_for_admins : Form
    {
        public LogIn_for_admins()
        {
            InitializeComponent();

        }
        Database db = new Database();

        

        private void LogIn_for_admins_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main_Menu add = new Main_Menu(new Session());
            add.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (db.connection.State != ConnectionState.Open)
                {
                    db.Connect();
                }
                string email = email_input.Text;
                string password = textBox1.Text;
                User user = db.GetUser(email, password);
                if (user.permission.ToString() != "ADMIN")
                {
                    MessageBox.Show("Acces denied!");
                    return;
                }
                this.Hide();
                Add_dish_test add = new Add_dish_test();
                add.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }

}
