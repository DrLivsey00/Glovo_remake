using Glovo.internal_pkg.models;
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

namespace Glovo.forms
{
    public partial class Add_dish_test : Form
    {
        public Add_dish_test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = textBox1.Text;
                double Price = Double.Parse(textBox2.Text);
                Dish dishToAdd = new Dish(Name, Price);
                DialogResult result = MessageBox.Show($"You sure, you want to delete {dishToAdd.dishName}?", $"Confirm adittion of {dishToAdd.dishName}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Если пользователь подтвердил удаление
                if (result == DialogResult.Yes)
                {

                    dishToAdd.AddDishToDb();
                    textBox2.Clear();
                    textBox1.Clear();
                    MessageBox.Show($"Dish {dishToAdd.dishName} was added!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
            
        }

        private void Add_dish_test_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu_managment add = new Menu_managment();
            add.Show();
        }
    }
}
