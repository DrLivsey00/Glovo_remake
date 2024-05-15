using Glovo.internal_pkg.models;
using Glovo.internal_pkg.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glovo.forms
{
    public partial class Log_up : Form
    {
        Database db = new Database();
        Session session = new Session();
        public Log_up()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.connection.State != ConnectionState.Open)
                {
                    db.Connect();
                }
                User user = new User();
                string password = textBox1.Text;
                string email = email_input.Text;
                if (!IsValidEmail(email))
                {
                    email_input.Text = "Invalid email";
                    email_input.ForeColor = Color.Red;
                    return;
                }
                if (!DontDublicate(email))
                {
                    MessageBox.Show("User already registered");
                    return;
                }
                if (password == null || password == string.Empty)
                {
                    textBox1.Text = "Invalid password";
                    textBox1.ForeColor = Color.Red;
                    return;
                }
                user.email = email;
                user.password = password;
                user.AddToDb();
                MessageBox.Show("Succes!!!");

                email_input.Clear();
                textBox1.Clear();
                session.userId = user.Id;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private static bool IsValidEmail(string email)
        {
            // Паттерн для проверки адреса электронной почты
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Проверка с использованием регулярного выражения
            return Regex.IsMatch(email, pattern);
        }
        private static bool DontDublicate(string email)
        {
            Database db = new Database();
            db.Connect();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = db.connection;
            cmd.CommandText = "SELECT * FROM users WHERE user_email = @email";
            cmd.Parameters.AddWithValue("@email", email);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void Log_up_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main_Menu m = new Main_Menu(session);
            m.Show();
        }
    }
}
