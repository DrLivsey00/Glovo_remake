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

namespace Glovo.forms
{
    public partial class Log_In : Form
    {
        Session session;
        Database db = new Database();
        public Log_In(Session session)
        {
            InitializeComponent();
            this.session = session;
        }

        private void log_up_Click(object sender, EventArgs e)
        {
            Log_up log_Up = new Log_up();
            this.Hide();
            log_Up.Show();
        }

        private void Log_In_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main_Menu main_Menu = new Main_Menu(session);
            main_Menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
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
                session.userId = user.Id;
                session.Logged = true;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn_for_admins ad = new LogIn_for_admins();
            ad.Show();
        }
    }
}
