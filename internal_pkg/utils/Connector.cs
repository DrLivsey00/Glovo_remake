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
    }
}
