using Glovo.forms;
using Glovo.internal_pkg.models;
using Glovo.internal_pkg.utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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

        }
        private void InitializeMenu()
        {
            int topMargin = 50;
            for (int i = 0; i < Menu.Count; i++)
            {
                Label nameLabel = new Label();
                nameLabel.Text = Menu[i].dishName;
                nameLabel.Top = topMargin + (i * 30);
                nameLabel.Left = 20;
                this.Controls.Add(nameLabel);

                Label priceLabel = new Label();
                priceLabel.Text = Menu[i].dishPrice.ToString(); // Вывод цены в формате денежной единицы
                priceLabel.Top = topMargin + (i * 30);
                priceLabel.Left = 150;
                this.Controls.Add(priceLabel);

                Button addButton = new Button();
                addButton.Text = "Додати";
                addButton.Top = topMargin + (i * 30);
                addButton.Left = 250;
                addButton.Click += (sender, e) => AddToCart(Menu[i]);
                this.Controls.Add(addButton);
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
            List<(Dish,int)> cart = session.Cart;
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_dish_test add_Dish_Test = new Add_dish_test();
            add_Dish_Test.Show();
        }
    }
}
