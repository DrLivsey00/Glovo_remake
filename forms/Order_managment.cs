using Glovo.internal_pkg.models;
using Glovo.internal_pkg.utils;
using System.Text;

namespace Glovo.forms
{
    public partial class Order_managment : Form
    {
        Database db = new Database();
        public Order_managment()
        {
            InitializeComponent();
            db.Connect();
            GetOrderList();
        }

        private void GetOrderList()
        {
            List<Order> orders = db.GetOrders();
            tableLayoutPanel1.Controls.Clear();
            if (orders.Count == 0 || orders == null)
            {
                tableLayoutPanel1.ColumnCount = 1;
                Label n = new Label();
                n.Text = "No orders now :(";

                n.AutoSize = true;
                n.Font = new Font("Segoe UI", 9.75F);

                tableLayoutPanel1.Controls.Add(n, 0, 0);
                tableLayoutPanel1.Width = n.Width + 10;
                tableLayoutPanel1.Left = label1.Left - 10;
                return;
            }

            tableLayoutPanel1.ColumnCount = 6;


            //tableLayoutPanel1.Dock = DockStyle.Fill;
            for (int i = 0; i < orders.Count; i++)
            {
                Label orderId = new Label();
                orderId.Text = "#" + orders[i].Id;
                orderId.AutoSize = true;
                orderId.Font = new Font("Segoe UI", 9.75F);

                // Створення Label для назви страви
                Label nameLabel = new Label();
                nameLabel.Text = db.GetUserById(int.Parse(orders[i].userId));
                nameLabel.AutoSize = true;
                nameLabel.Font = new Font("Segoe UI", 9.75F);

                // Створення Label для ціни
                Label priceLabel = new Label();
                priceLabel.Text = "Price: " + orders[i].Price.ToString("C");
                priceLabel.AutoSize = true;
                priceLabel.Font = new Font("Segoe UI", 9.75F);



                List<string> strings = new List<string>();
                foreach (int id in orders[i].dishIds)
                {
                    strings.Add(db.GetDishName(id));
                }
                StringBuilder stringBuilder = new StringBuilder();
                foreach (string c in strings)
                {
                    stringBuilder.Append(c).Append(" ");
                }
                Label ListLabel = new Label();
                ListLabel.Text = stringBuilder.ToString();
                ListLabel.AutoSize = true;
                ListLabel.Font = new Font("Segoe UI", 9.75F);


                // Створення кнопки "Додати"
                int index = i;
                Button addButton = new Button();
                addButton.Text = "Видалити";
                addButton.AutoSize = false;
                addButton.Dock = DockStyle.Fill;
                addButton.Font = new Font("Segoe UI", 9.75F);
                addButton.Click += (sender, e) => DeleteOrder(orders[index].Id);

                Button Cinfirm = new Button();
                Cinfirm.Text = "Підтвердити";
                Cinfirm.AutoSize = false;
                Cinfirm.Dock = DockStyle.Fill;
                Cinfirm.Font = new Font("Segoe UI", 9.75F);
                Cinfirm.Click += (sender, e) => ConfirmOrder(orders[index].Id);

                // Додавання елементів до TableLayoutPanel
                tableLayoutPanel1.Controls.Add(orderId, 0, i);
                tableLayoutPanel1.Controls.Add(nameLabel, 1, i);
                tableLayoutPanel1.Controls.Add(priceLabel, 2, i);
                tableLayoutPanel1.Controls.Add(ListLabel, 3, i);
                tableLayoutPanel1.Controls.Add(Cinfirm, 4, i);
                tableLayoutPanel1.Controls.Add(addButton, 5, i);
            }

        }
        private void DeleteOrder(int id)
        {
            DialogResult res = MessageBox.Show($"You sure tou want to delete order #{id}?", $"Confirm deletion of order #{id}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                db.DeleteOrderById(id);
                MessageBox.Show($"Order #{id} was deleted");
                GetOrderList();
            }
        }

        private void ConfirmOrder(int id)
        {
            DialogResult res = MessageBox.Show($"You sure tou want to confirm order #{id}?", $"Confirm confiramtion of order #{id}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                db.ConfirmOrderById(id);
                MessageBox.Show($"Order #{id} was confirmed");
                GetOrderList();
            }
        }

        private void Order_managment_FormClosed(object sender, FormClosedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
        }
    }
}
