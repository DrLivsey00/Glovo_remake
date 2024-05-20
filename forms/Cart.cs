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
using System.Xml;

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
            List<(Dish, int)> cart = current.Cart;
            oprice = 0;
            int topMargin = 50;

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Top = label1.Bottom + 10; // Розміщення під Label1 з відступом
            tableLayoutPanel.Left = label1.Left - 100;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.ColumnCount = 2; // Три колонки для назви, ціни та кнопки
            this.Controls.Add(tableLayoutPanel);
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F)); // Ширина колонки для назви страви
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F)); // Ширина колонки для ціни
            if (cart.Count > 0)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    Label nameLabel = new Label();
                    nameLabel.Text = cart[i].Item1.dishName;
                    nameLabel.Top = topMargin + (i * 30);
                    nameLabel.Left = 20;
                    nameLabel.Font = new Font("Segoe UI", 9.75F);
                    this.Controls.Add(nameLabel);

                    Label priceLabel = new Label();
                    priceLabel.Text = cart[i].Item2.ToString(); // Вывод цены в формате денежной единицы
                    priceLabel.Top = topMargin + (i * 30);
                    priceLabel.Left = 150;
                    priceLabel.Font = new Font("Segoe UI", 9.75F);
                    this.Controls.Add(priceLabel);

                    oprice += cart[i].Item1.dishPrice*cart[i].Item2;

                    tableLayoutPanel.Controls.Add(nameLabel, 0, i);
                    tableLayoutPanel.Controls.Add(priceLabel, 1, i);
                }
                Label opriceLabel = new Label();
                opriceLabel.AutoSize = true;
                opriceLabel.Text = "Вартість замовлення: " + oprice.ToString("C");
                opriceLabel.Top = tableLayoutPanel.Bottom + 10;
                opriceLabel.Left = tableLayoutPanel.Left + 50;
                opriceLabel.Font = new Font("Segoe UI", 9.75F);
                this.Controls.Add(opriceLabel);
                btn_back.Top = opriceLabel.Bottom + 10;
                btn_proceed.Top = opriceLabel.Bottom + 10;
            }
         }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();  // Скрыть текущую форму
        }

        private void btn_proceed_Click(object sender, EventArgs e)
        {
            try
            {
                db.Connect();
                db.ProceedOrder(current.Cart, current.userId, oprice);
                current.Cart = new List<(Dish, int)>();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void Cart_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main_Menu main_Menu = new Main_Menu(current);
            main_Menu.Show();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            //GetOrderList();
        }
        private void Cart_Shown(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
