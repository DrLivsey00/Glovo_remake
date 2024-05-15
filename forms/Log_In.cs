using Glovo.internal_pkg.models;
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
                User user = new User();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
