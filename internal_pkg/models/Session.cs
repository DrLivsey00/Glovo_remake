namespace Glovo.internal_pkg.models
{
    public class Session
    {
        uint userId;
        List<uint> Cart;
        Permission Permission;

        public Session()
        {
            userId = 0;
            Cart= new List<uint>();
            Permission = Permission.USER;
        }

    }
}
