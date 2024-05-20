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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }
    }
}
