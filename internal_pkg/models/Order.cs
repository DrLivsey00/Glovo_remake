﻿namespace Glovo.internal_pkg.models
{
    public class Order
    {
        public int Id;
        public string userId;
        public List<int> dishIds;
        public double Price;

        public Order() {
            dishIds = new List<int>();
        }
        
    }
}
