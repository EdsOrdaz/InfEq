using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InfEq
{
    public partial class DeleteView : Form
    {
        public DeleteView()
        {
            InitializeComponent();
        }

        private void DeleteView_Load(object sender, EventArgs e)
        {
            int ID = DeleteID.ID;
            if(ID<1)
            {
                MessageBox.Show("Debes ingresar un ID Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is DeleteID);
                if (frm1 != null)
                {
                    frm1.Close();
                }
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is DeleteView);
                if (frm != null)
                {
                    frm.BringToFront();
                    this.Close();
                }
                else
                {
                    DeleteID DeleteID = new DeleteID();
                    DeleteID.Show();
                    this.Close();
                }
            }


            try
            {
                using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                {
                    conexion.Open();
                    String sql = "SELECT TOP(1) * FROM " + database.tablabase + " WHERE XID="+ID;
                    SqlCommand comm = new SqlCommand(sql, conexion);
                    SqlDataReader nwReader = comm.ExecuteReader();
                    if(!nwReader.Read())
                    {
                        MessageBox.Show("No existe informacion con el ID " + ID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    else
                    {
                        nombrepc.Text = nwReader["nombreequipo"].ToString();
                        marca.Text = nwReader["marca"].ToString();
                        modelo.Text = nwReader["modelo"].ToString();
                        serie.Text = nwReader["numeroserie"].ToString();
                        bbase.Text = nwReader["base"].ToString();
                        departamento.Text = nwReader["departamento"].ToString();
                        usuario.Text = nwReader["nombre"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la busqueda\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form frm1 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Buscar);
            if (frm1 != null)
            {
                frm1.Close();
            }
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Buscar);
            if (frm != null)
            {
                frm.BringToFront();
                this.Close();
            }
            else
            {
                Buscar Buscar = new Buscar();
                Buscar.Show();
                Buscar.BuscarporId(DeleteID.ID);
                //this.Close();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int ID = DeleteID.ID;
            DialogResult msj = MessageBox.Show("¿Quieres eliminar este registro?\nNo se prodan deshacer los cambios.", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(msj == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                    {
                        conexion.Open();
                        String sql = "DELETE FROM " + database.tablabasemacs + " WHERE XID=" + ID;
                        SqlCommand comm = new SqlCommand(sql, conexion);
                        comm.ExecuteReader();
                    }
                    using (SqlConnection conexions = new SqlConnection(database.nombresqlexpress))
                    {
                        conexions.Open();
                        String sqls = "DELETE FROM " + database.tablabase + " WHERE XID=" + ID;
                        SqlCommand comms = new SqlCommand(sqls, conexions);
                        comms.ExecuteReader();
                    }
                    MessageBox.Show("Registro eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al borrar registros.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
