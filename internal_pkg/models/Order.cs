namespace Glovo.internal_pkg.models
{
    public class Order
    {
        public int Id;
        public string userId;
        public List<int> dishIds;
        public double Price;
        public string status;

        public Order() {
            dishIds = new List<int>();
            status = "IN_PROGRESS";
        }
        
    }
}
