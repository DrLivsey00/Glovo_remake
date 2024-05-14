using Glovo.internal_pkg.models;
using Newtonsoft.Json;

namespace Glovo.internal_pkg.utils
{
    public class Connection
    {
        public string filePath;

        public Connection(string filePath)
        {
            if (filePath == null || filePath.Length == 0)
            {
                throw new ArgumentException("Wrong file path!");
            }
            this.filePath = filePath;
        }

        public List<Order> GetOrders()
        {
            string data = File.ReadAllText(filePath);
            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(data);
            return orders;
        }


    }
}
