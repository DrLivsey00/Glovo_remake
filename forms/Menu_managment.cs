using Glovo.internal_pkg.models;
using Glovo.internal_pkg.utils;
using System.Windows.Forms;


namespace Glovo.forms
{
    public partial class Menu_managment : Form
    {
        Database db = new Database();
        List<Dish> Menu;
        public Menu_managment()
        {
            InitializeComponent();
            db.Connect();
            Menu = db.GetMenuList();
            InitializeMenu();
        }

        private void InitializeMenu()
        {

           
            //tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F)); // Ширина колонки для назви страви
            //tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F)); // Ширина колонки для ціни
            //tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tableLayoutPanel1.Controls.Clear();
            if (Menu.Count == 0)
            {
                Label label = new Label();
                label.Text = "Database is empty!";
                label.AutoSize = true;
                label.Font = new Font("Segoe UI", 9.75F,FontStyle.Bold);
                tableLayoutPanel1.Controls.Add(label, 1, 1);
            }
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
                addButton.Text = "IDI";
                addButton.AutoSize = false;
                addButton.Dock = DockStyle.Fill;
                addButton.Font = new Font("Segoe UI", 9.75F);
                addButton.Click += (sender, e) => DeleteDish(Menu[index]);

                // Додавання елементів до TableLayoutPanel
                tableLayoutPanel1.Controls.Add(nameLabel, 0, i);
                tableLayoutPanel1.Controls.Add(priceLabel, 1, i);
                tableLayoutPanel1.Controls.Add(addButton, 2, i);
                tableLayoutPanel1.Controls.Add(addButton, 2, i);
            }

        }
        private void DeleteDish(Dish dish)
        {
            // Показать модальное окно с вопросом об удалении
            DialogResult result = MessageBox.Show($"You sure, you want to delete {dish.dishName}?", $"Confirm deletion of {dish.dishName}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Если пользователь подтвердил удаление
            if (result == DialogResult.Yes)
            {
                Menu.Remove(dish);
                db.DeleteDish(dish.id);
                InitializeMenu();
                MessageBox.Show($"Dish {dish.dishName} was deleted!");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_dish_test add = new Add_dish_test();
            add.Show();
        }

        private void Menu_managment_FormClosed(object sender, FormClosedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
        }
    }
}
