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
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Top = label1.Bottom + 10; // ��������� �� Label1 � ��������
            tableLayoutPanel.Left = label1.Left - 150;   
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.ColumnCount = 3; // ��� ������� ��� �����, ���� �� ������
            this.Controls.Add(tableLayoutPanel);
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F)); // ������ ������� ��� ����� ������
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F)); // ������ ������� ��� ����
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));

            for (int i = 0; i < Menu.Count; i++)
            {
                // ��������� Label ��� ����� ������
                Label nameLabel = new Label();
                nameLabel.Text = Menu[i].dishName;
                nameLabel.AutoSize = true;

                // ��������� Label ��� ����
                Label priceLabel = new Label();
                priceLabel.Text = "Price: " + Menu[i].dishPrice.ToString("C");
                priceLabel.AutoSize = true;

                // ��������� ������ "������"
                int index = i;
                Button addButton = new Button();
                addButton.Text = "������";
                addButton.AutoSize = true;
                addButton.Click += (sender, e) => AddToCart(Menu[index]);

                // ��������� �������� �� TableLayoutPanel
                tableLayoutPanel.Controls.Add(nameLabel, 0, i);
                tableLayoutPanel.Controls.Add(priceLabel, 1, i);
                tableLayoutPanel.Controls.Add(addButton, 2, i);
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

            if (existingItem != default) // ���� ����� ��� ������������ � �������
            {
                // ��������� ���������� �����
                int index = cart.IndexOf(existingItem);
                cart[index] = (existingItem.Item1, existingItem.Item2 + 1);
            }
            else
            {
                // �������� ����� � ������� � ����������� 1
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
    }
}
