using Glovo.internal_pkg.models;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Numerics;
using System.Data.SQLite;
using Newtonsoft.Json.Bson;
using System.Data.SqlClient;

namespace Glovo.internal_pkg.utils
{
    public class Database
    {
        internal SQLiteConnection connection;

        public Database() {
            connection = new SQLiteConnection(@"Data Source = C:\study\Glovo\internal_pkg\db\database.db; Version = 3");
        }

        public void  Connect()
        {
            connection.Open();
            
        }

        public List<Dish> GetMenuList()
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = @"SELECT dishId,dishName, dishPrice FROM dishes";
            cmd.Connection = connection;
            List<Dish> Menulist = new List<Dish>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Создание объекта для каждого блюда
                    int id = reader.GetInt32(0);
                    string dishName = reader.GetString(1); // Получение названия блюда из первого столбца
                    double dishPrice = reader.GetDouble(2); // Получение цены блюда из второго столбца

                    Dish dish = new Dish(id,dishName, dishPrice);

                    Menulist.Add(dish);
                    
                }
            }
            return Menulist;

        }

        public void ProceedOrder(List<(Dish,int)> orderItems, int userID,double order_price)
        {
            int orderId = 0;
            if (orderItems == null || orderItems.Count == 0)
            {
                throw new ArgumentNullException("Cart can`t be empty or null...");
            }
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO orders (user_id,order_price) VALUES (@userId,@price)";
            cmd.Parameters.AddWithValue("@userId", userID);
            cmd.Parameters.AddWithValue("@price", order_price);
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"SELECT MAX(order_id) FROM orders";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                  orderId = reader.GetInt32(0);
                }
                
            }

            foreach ((Dish dish, int quantity) in orderItems)
            {
                cmd.CommandText = @"INSERT INTO order_details (order_id,dish_id,quantity) VALUES (@orderId,@dishId,@quantity)";
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.Parameters.AddWithValue("@dishId", dish.id);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.ExecuteNonQuery();
            }
        }

        public User GetUser(string email, string password)
        {
            User user = new User();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM users WHERE user_email = @email";
            cmd.Parameters.AddWithValue("@email", email);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    user.Id = reader.GetInt32(0);
                    user.email = reader.GetString(1);
                    user.password = reader.GetString(2);
                    string permission = reader.GetString(3);
                    if (permission == "ADMIN")
                    {
                        user.permission = Permission.ADMIN;
                    }
                    else
                    {
                        user.permission = Permission.USER;
                    }
                    if (password!=user.password)
                    {
                        throw new Exception("Wrong password");
                    }
                }
                else
                {
                    throw new Exception("Invalid email!");
                }
            }
            return user;

        }
    }
}
