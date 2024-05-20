using Glovo.forms;
using Glovo.internal_pkg.models;
using Glovo.internal_pkg.utils;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Cart = Glovo.forms.Cart;

namespace Glovo
{
    public partial class Main_Menu : Form
    {
        Session session;
        Database Database = new Database();
        List<Dish> Menu = new List<Dish>();
        public Main_Menu(Session session)
        {
            InitializeComponent();
            this.session = session;
            Database.Connect();
            Menu = Database.GetMenuList();
            InitializeMenu();
            ProcessButton();

        }
        private void InitializeMenu()
        {
            
            if (Menu.Count == 0)
            {
                Label label = new Label();
                label.Text = "Nothing in stock :(";
                label.AutoSize = true;
                label.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
                tableLayoutPanel1.Controls.Add(label, 1, 1);
                return;
            }
            tableLayoutPanel1.Controls.Clear();
            for (int i = 0; i < Menu.Count; i++)
            {
                // Створення Label для назви страви
                Label nameLabel = new Label();
                nameLabel.Text = Menu[i].dishName;
                nameLabel.AutoSize = true;
                nameLabel.Font = new Font("Segoe UI", 9.75F);

                // Створення Label для ціни
                Label priceLabel = new Label();
                priceLabel.Text = "Price: " + Menu[i].dishPrice.ToString("C");
                priceLabel.AutoSize = true;
                priceLabel.Font = new Font("Segoe UI", 9.75F);

                // Створення кнопки "Додати"
                int index = i;
                Button addButton = new Button();
                addButton.Text = "Додати";
                addButton.AutoSize = false;
                addButton.Dock = DockStyle.Fill;
                addButton.Font = new Font("Segoe UI", 9.75F);
                addButton.Click += (sender, e) => AddToCart(Menu[index]);

                // Додавання елементів до TableLayoutPanel
                tableLayoutPanel1.Controls.Add(nameLabel, 0, i);
                tableLayoutPanel1.Controls.Add(priceLabel, 1, i);
                tableLayoutPanel1.Controls.Add(addButton, 2, i);
            }
        }
        private void AddToCart(Dish dish)
        {
            if (dish == null) return;
            if (session.userId == 0)
            {
                MessageBox.Show("Please log in");
                return;
            }
            List<(Dish, int)> cart = session.Cart;
            var existingItem = cart.FirstOrDefault(item => item.Item1.dishName == dish.dishName);

            if (existingItem != default) // Если блюдо уже присутствует в корзине
            {
                // Увеличить количество блюда
                int index = cart.IndexOf(existingItem);
                cart[index] = (existingItem.Item1, existingItem.Item2 + 1);
            }
            else
            {
                // Добавить блюдо в корзину с количеством 1
                cart.Add((dish, 1));
            }
            MessageBox.Show($"{dish.dishName} added!");
            session.Cart = cart;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!session.Logged)
            {
                this.Hide();
                Log_In log_In = new Log_In(session);
                log_In.Show();
            }
            else
            {
                session = new Session();
                MessageBox.Show("Logged out!");
                ProcessButton();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (session.Cart.Count == 0)
            {
                MessageBox.Show("Cart is empty!");
                return;
            }
            this.Hide();
            Cart cart = new Cart(session);
            cart.Show();
        }
        private void ProcessButton()
        {
            if (session.Logged)
            {
                button1.Text = "Log out";
            }
            else
            {
                button1.Text = "Log in";
            }
        }

        private void Main_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin a =  new Admin();
            a.Show();
        }
    }
}
