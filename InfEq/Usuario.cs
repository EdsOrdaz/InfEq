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
            tooltipsubirxml.SetToolTip(subirxml, "Cargar archivo XML");
            tooltipreporte.SetToolTip(reportemensual, "Generar Programa Mensual");
            toolTipreportes.SetToolTip(reportes, "Report InfEq Manager");
            toolTipsirac.SetToolTip(sirac, "Ver datos de SiRAc");
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

        private void Subirxml_Click(object sender, EventArgs e)
        {
            SubirXML.lista_macs.Clear();
            SubirXML.lista_archivos.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "XML Files (*.xml)|*.xml";
            ofd.FilterIndex = 0;
            ofd.DefaultExt = "xml";
            SubirXML.contar = 0;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (String rutaarchivo in ofd.FileNames)
                    {
                        SubirXML.verificarxml(rutaarchivo);
                    }
                    SubirXML.leer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error\nMensaje: " + ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Reportemensual_Click(object sender, EventArgs e)
        {
            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ReporteMensual);
            if (frm1 != null)
            {
                frm1.Close();
            }
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ReporteMensual);
            if (frm != null)
            {
                frm.BringToFront();
            }
            else
            {
                ReporteMensual ReporteMensual = new ReporteMensual();
                ReporteMensual.Show();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Sirac);
            if (frm1 != null)
            {
                frm1.Close();
            }
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Sirac);
            if (frm != null)
            {
                frm.BringToFront();
            }
            else
            {
                Sirac Sirac = new Sirac();
                Sirac.Show();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (database.EsAdministrador())
            {
                Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ReportInfEq);
                if (frm1 != null)
                {
                    frm1.Close();
                }
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ReportInfEq);
                if (frm != null)
                {
                    frm.BringToFront();
                }
                else
                {
                    ReportInfEq ReportInfEq = new ReportInfEq();
                    ReportInfEq.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Debes ejecutar el programa en modo administrador para poder ejecutar y detener procesos", "No Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
