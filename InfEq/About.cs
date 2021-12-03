using System;
using System.Windows.Forms;

namespace InfEq
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }
        
        private void About_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            version.Text = "v" + database.versioninfeq;
        }
    }
}
