using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using static InfEq.Datos;
using System.Management;
using System.Drawing;

namespace InfEq
{
    public partial class Prueba : Form
    {
        public Prueba()
        {
            InitializeComponent();
        }

        private void Prueba_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Gray;
            this.BackColor = Color.Gray;
        }
    }
}
