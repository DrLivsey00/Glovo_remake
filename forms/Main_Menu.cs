using Glovo.internal_pkg.models;

namespace Glovo
{
    public partial class Main_Menu : Form
    {
        Session session;
        public Main_Menu(Session session)
        {
            InitializeComponent();
            this.session = session;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
