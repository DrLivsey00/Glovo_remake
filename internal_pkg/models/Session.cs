﻿namespace Glovo.internal_pkg.models
{
    public class Session
    {
        internal int userId;
        internal List<(Dish,int)> Cart;
        internal Permission Permission;
        public bool Logged { get;set; }

        public Session()
        {
            userId = 0;
            Cart= new List<(Dish, int)>();
            Permission = Permission.USER;
            Logged = false;
        }

    }
}
