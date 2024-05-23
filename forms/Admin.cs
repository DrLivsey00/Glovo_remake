using Glovo.internal_pkg.models;
using Glovo.internal_pkg.utils;

namespace Glovo.forms
{
    public partial class Admin : Form
    {
        Database db = new Database();
        public Admin()
        {
            InitializeComponent();
            db.Connect();
            LoadStatistics();
        }
        private void LoadStatistics()
        {
            try
            {
                var statistics = db.GetStatistics();
                var totalUsers = statistics.TotalUsers;
                var totalOrders = statistics.TotalOrders;
                var totalProfit = statistics.TotalOrderSum;

                total_orders_label.Text = "Total orders: " + totalOrders.ToString();
                total_orders_users.Text = "Total users: " + totalUsers.ToString();
                total_profit_label.Text = "Total profit: " + totalProfit.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_managment m = new Menu_managment();
            this.Hide();
            m.Show();
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main_Menu m = new Main_Menu(new Session());
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Order_managment order_Managment = new Order_managment();
            order_Managment.Show();
        }
    }
}
