using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InfEq
{
    public partial class DeleteID : Form
    {
        public static int ID;
        public DeleteID()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(numericUpDown1.Value);

            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is DeleteView);
            if (frm1 != null)
            {
                frm1.Close();
            }
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is DeleteView);
            if (frm != null)
            {
                frm.BringToFront();
            }
            else
            {
                DeleteView DeleteView = new DeleteView();
                DeleteView.Show();
                this.Close();
            }
        }

        private void NumericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void DeleteID_Load(object sender, EventArgs e)
        {

        }
    }
}
