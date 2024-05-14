using Glovo.internal_pkg.utils;
using Newtonsoft.Json;

namespace Glovo.internal_pkg.models
{
    public class Dish
    {
        public int id { get; set; }
        public string dishName { get; set; }
        public double dishPrice { get; set; }
        Connection connection;

        public Dish(string dishName, double dishPrice)
        {
            this.id = 0;
            this.dishName = dishName;
            this.dishPrice = dishPrice;
            this.connection = new Connection(@"C:\study\Glovo\internal_pkg\db\Dishes.json");
        }

        public void AddDishToDb()
        {
            
        }
    }
}
