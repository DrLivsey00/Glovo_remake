using Glovo.internal_pkg.utils;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glovo.internal_pkg.models
{
    public class User
    {
        public int Id;
        public string email;
        public string password;
        public Permission permission;
        Database db = new Database();

        public User() { 
            Id= 0;
            email = "";
            permission = Permission.USER;

        }


        public void AddToDb()
        {
            if (this == null || password == null || password == String.Empty)
            {
                throw new Exception("Invalid user");
            }
            db.Connect();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = @"INSERT INTO users (user_email,user_password,user_permission) VALUES (@email,@pass,@perm)";
            cmd.Connection = db.connection;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("pass", password);
            cmd.Parameters.AddWithValue("@perm", permission.ToString());
            int i = cmd.ExecuteNonQuery();
            cmd.CommandText = @"SELECT MAX(user_id) FROM users";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                     Id = reader.GetInt32(0);
                }
            }
            if (i < 1)
            {
                throw new Exception("Something went wrong...");
            }


        }
    }
}
