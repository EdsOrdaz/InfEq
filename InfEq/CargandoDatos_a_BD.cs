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
    public partial class CargandoDatos_a_BD : Form
    {
        public CargandoDatos_a_BD()
        {
            InitializeComponent();
        }

        private void CargandoDatos_a_BD_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Gray;
            this.BackColor = Color.Gray;
        }
    }
}
