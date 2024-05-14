using Glovo.internal_pkg.models;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Numerics;
using System.Data.SQLite;
using Newtonsoft.Json.Bson;

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
            MessageBox.Show("Connected!");
            
        }
    }
}
