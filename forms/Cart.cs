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
using Button = System.Windows.Forms.Button;

namespace Glovo.forms
{
    public partial class Cart : Form
    {
        Session current;
        Database db = new Database();
        double oprice;
        public Cart(Session session)
        {
            InitializeComponent();
            current = session;
            GetOrderList();
        }
        private void GetOrderList()
        {
            List<(Dish,int)> cart = current.Cart;
            oprice = 0;
            int topMargin = 50;
            if (cart.Count > 0)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    Label nameLabel = new Label();
                    nameLabel.Text = cart[i].Item1.dishName;
                    nameLabel.Top = topMargin + (i * 30);
                    nameLabel.Left = 20;
                    this.Controls.Add(nameLabel);

                    Label priceLabel = new Label();
                    priceLabel.Text = cart[i].Item2.ToString(); // Вывод цены в формате денежной единицы
                    priceLabel.Top = topMargin + (i * 30);
                    priceLabel.Left = 150;
                    this.Controls.Add(priceLabel);
                    oprice += cart[i].Item1.dishPrice;
                }
                Label opriceLabel = new Label();
                opriceLabel.Text = "Вартість замовлення: "+oprice.ToString();
            }
            else
            {
                Label opriceLabel = new Label();
                opriceLabel.Text = "Cart is empty!!!";
                opriceLabel.ForeColor = Color.Red;
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Main_Menu main_Menu = new Main_Menu(current);
            this.Hide();
            main_Menu.Show();
        }

        private void btn_proceed_Click(object sender, EventArgs e)
        {
            try
            {
                db.Connect();
                db.ProceedOrder(current.Cart,current.userId,oprice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
