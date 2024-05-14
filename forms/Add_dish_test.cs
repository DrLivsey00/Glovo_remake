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
            string Name = textBox1.Text;
            double Price = Double.Parse(textBox2.Text);
            Dish dishToAdd = new Dish(Name, Price);
            dishToAdd.AddDishToDb();
        }
    }
}
