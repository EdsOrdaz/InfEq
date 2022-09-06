using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace InfEq
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void Cerrarsesion_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Quieres cerrar sesión?", "Cerrar Sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                database.logueado = false;
                database.privilegios = false;
                this.Close();
            }
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            toolTipagregarusuario.SetToolTip(agregarusuario, "Agregar Usuario");
            toolTipcerrarsesion.SetToolTip(cerrarsesion, "Cerrar Sesión");
            toolTiplistausuario.SetToolTip(listausuario, "Lista de Usuarios");
            toolTiprConfCorreo.SetToolTip(config_correo, "Configurar datos al enviar Correo");
            toolTip1.SetToolTip(delete, "Eliminar datos de equipo");
        }

        private void Listausuario_Click(object sender, EventArgs e)
        {
            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is EditarUsuario);
            if (frm1 != null)
            {
                frm1.Close();
            }
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Listausuarios);
            if (frm != null)
            {
                frm.BringToFront();
            }
            else
            {
                Listausuarios listausuarios = new Listausuarios();
                listausuarios.Show();
            }
        }

        private void Agregarusuario_Click(object sender, EventArgs e)
        {
            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is EditarUsuario);
            if (frm1 != null)
            {
                frm1.Close();
            }
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is AgregarUsuario);
            if (frm != null)
            {
                frm.BringToFront();
            }
            else
            {
                AgregarUsuario agregarusuario = new AgregarUsuario();
                agregarusuario.Show();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is DeleteID);
            if (frm1 != null)
            {
                frm1.Close();
            }
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is DeleteID);
            if (frm != null)
            {
                frm.BringToFront();
            }
            else
            {
                //Permitir solo al SuperAdmin
                if (database.useruid == 1)
                {
                    DeleteID DeleteID = new DeleteID();
                    DeleteID.Show();
                }
                else
                {
                    MessageBox.Show("No tienes permiso para eliminar informacón", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void config_correo_Click(object sender, EventArgs e)
        {
            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Configurar_correo);
            if (frm1 != null)
            {
                frm1.Close();
            }
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Configurar_correo);
            if (frm != null)
            {
                frm.BringToFront();
            }
            else
            {
                Configurar_correo configurarcorreo = new Configurar_correo();
                configurarcorreo.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Buscar);
            if (frm != null)
            {
                frm.BringToFront();
            }
            else
            {
                Buscar Buscar = new Buscar();
                Buscar.Show();
            }
        }
    }
}
