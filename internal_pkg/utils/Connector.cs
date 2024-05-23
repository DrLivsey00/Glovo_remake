using Glovo.internal_pkg.models;
using System.Data.SQLite;

namespace Glovo.internal_pkg.utils
{
    public class Database
    {
        internal SQLiteConnection connection;

        public Database() {
            connection = new SQLiteConnection(@"Data Source = C:\study\KP_Mikhrin\internal_pkg\db\database.db; Version = 3");
        }

        public void Connect()
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

                    Dish dish = new Dish(id, dishName, dishPrice);

                    Menulist.Add(dish);

                }
            }
            return Menulist;

        }
        public string GetDishName(int id)
        {
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT dishName FROM dishes WHERE dishId = @id";
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }
            }
            return null;
        }
        public void ProceedOrder(List<(Dish, int)> orderItems, int userID, double order_price)
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
                    if (password != user.password)
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
        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();


            string orderQuery = "SELECT order_id, user_id, order_price, order_status FROM orders WHERE order_status = @orderst";
            string orderDetailsQuery = "SELECT order_id, dish_id FROM order_details WHERE order_id = @orderId";

            using (SQLiteCommand orderCmd = new SQLiteCommand(orderQuery, connection))
            {
                orderCmd.Parameters.AddWithValue("@orderst", "IN_PROGRESS");
                using (SQLiteDataReader orderReader = orderCmd.ExecuteReader())
                {
                    while (orderReader.Read())
                    {
                        Order order = new Order();
                        order.Id = orderReader.GetInt32(0);
                        order.userId = orderReader.GetInt32(1).ToString();
                        order.Price = orderReader.GetDouble(2);
                        order.status = orderReader.GetString(3);

                        using (SQLiteCommand orderDetailsCmd = new SQLiteCommand(orderDetailsQuery, connection))
                        {
                            orderDetailsCmd.Parameters.AddWithValue("@orderId", order.Id);

                            using (SQLiteDataReader orderDetailsReader = orderDetailsCmd.ExecuteReader())
                            {
                                while (orderDetailsReader.Read())
                                {
                                    order.dishIds.Add(orderDetailsReader.GetInt32(1));
                                }
                            }
                        }

                        orders.Add(order);
                    }
                }
            }

            return orders;
        }
        public (int TotalUsers, int TotalOrders, double TotalOrderSum) GetStatistics()
        {
            string query = @"
            SELECT 
            (SELECT COUNT(*) FROM users) AS TotalUsers,
            (SELECT COUNT(*) FROM orders) AS TotalOrders,
            (SELECT SUM(order_price) FROM orders WHERE order_status = 'CONFIRMED') AS TotalOrderSum";

            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int totalUsers = reader.GetInt32(0);
                        int totalOrders = reader.GetInt32(1);
                        double totalOrderSum = reader.IsDBNull(2) ? 0 : reader.GetDouble(2);

                        return (totalUsers, totalOrders, totalOrderSum);
                    }
                    else
                    {
                        throw new Exception("Failed to retrieve statistics");
                    }
                }
            }
        }

        public void DeleteDish(int id)
        {
            string query = "DELETE FROM dishes WHERE dishId = @id";

            // Создание объекта команды и указание параметров
            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                // Выполнение команды SQL
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected < 0)
                {
                    throw new Exception("No dish with this id.");
                }
            }
        }

        public string GetUserById(int id)
        {
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT user_email FROM users WHERE user_id = @id";
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }
            }
            return "";
        }
        public void DeleteOrderById(int id)
        {
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "DELETE FROM orders WHERE order_id = @id";
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
            }
        }
        public void ConfirmOrderById(int id)
        {
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE orders SET order_status = 'CONFIRMED' WHERE order_id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                }
        }
    }
}