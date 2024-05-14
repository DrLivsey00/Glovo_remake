using Glovo.internal_pkg.utils;
using Newtonsoft.Json;
using System.Data.SQLite;

namespace Glovo.internal_pkg.models
{
    public class Dish
    {
        public int id { get; set; }
        public string dishName { get; set; }
        public double dishPrice { get; set; }

        public Dish(string dishName, double dishPrice)
        {
            this.id = 0;
            this.dishName = dishName;
            this.dishPrice = dishPrice;
           
        }

        public void AddDishToDb()
        {
            Database db = new Database();
            db.Connect();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = @"INSERT INTO dishes (dishName,dishPrice) VALUES (@dishName,@dishPrice)";
            cmd.Connection = db.connection;
            cmd.Parameters.AddWithValue("@dishName", dishName);
            cmd.Parameters.AddWithValue("dishPrice", dishPrice);
            int i = cmd.ExecuteNonQuery();
            if (i < 1)
            {
                throw new Exception("Something went wrong...");
            }
        }
    }
}
