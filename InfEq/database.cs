using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static InfEq.Datos;

namespace InfEq
{
    class database
    {
        /*
         *  ACTIVAR SI ESTA EN AMBIENTE DE PRUEBAS
         *  LA INFORMACION SE GUARDARA EN SQL
         *  EN EL EQUIPO 192.168.150.1
         */
        public static Boolean pruebas = false;



        /*
         V3.2.0
            - Se agrega opcion de autocomplementar en campo de usuario
            - Se agrega nuevo cuadro para poder ver las macs y copiarlas

         V3.18
            - Se agrega opcion de busqueda 2022
            - Se repara exportacion a excel
        */
        //version del software
        public static String versioninfeq = "3.2.0";
        public static String versioninfeq_hash = "070afde0274dc6039a8a8949d12a15cd";
        public static Boolean sw_actualizado = true;
        public static Boolean sw_actualizado_error = false;

        //version del xml
        public static String versionxml = "3";


        //lista de xid repetidos al subir informacion
        public static List<string> xids = new List<string>();

        //login
        public static int useruid;
        public static String userlogin = "";
        public static Boolean logueado = false;
        public static Boolean privilegios = false;
        public static int ventanalogin = 0;

        //tablas de base de datos
        public static String tablabase = "equipos";
        public static String tablabaseview = "EquiposReporte";
        public static String tablausuarios = "Usuarios";
        public static String tablabasemacs = "MacAddress";
        public static String tablaconfiguracion = "Configuracion";
        public static String view_configuracion = "Config_InfEq";

        //Datos de Vista de configuracion (view_configuracion)
        public static String view_conf_correo_af;
        public static String view_conf_correo_ti;

        //Datos servidor UNNE
        public static String servidor = "148.223.153.37,5314";
        public static String basededatos = "InfEq";
        public static String usuariobd = "eordazs";
        public static String passbd = "Corpame*2013";


        //Datos servidor EDSON
        public static String servidorP = "192.168.150.1,5314";
        public static String basededatosP = "InfEq";
        public static String usuariobdP = "sa";
        public static String passbdP = "Corpame*2013";

        public static string nsqlP= "server=" + servidorP + "; database=" + basededatosP + " ;User ID=" + usuariobdP + ";Password=" + passbdP + "; integrated security = false ; MultipleActiveResultSets=True";
        public static string nsqlEx= "server=" + servidor + "; database=" + basededatos + " ;User ID=" + usuariobd + ";Password=" + passbd + "; integrated security = false ; MultipleActiveResultSets=True";

        public static String nombresqlexpress = (pruebas == false) ? nsqlEx : nsqlP;


        //Datos servidor Sirac
        public static String servivorSirac = "148.223.153.43\\MSSQLSERVER1";
        public static String basededatosSirac = "bd_SiRAc";
        public static String usuariobdSirac = "sa";
        public static String passbdSirac = "At3n4";

        public static string nsqlExSirac= "server=" + servivorSirac + "; database=" + basededatosSirac + " ;User ID=" + usuariobdSirac + ";Password=" + passbdSirac + "; integrated security = false ; MultipleActiveResultSets=True";

        //Datos Extras
        public static Boolean botoncargar=true;
        public static int macsaddnum = 0;

        //XID para ver MacAddress
        public static int MAC_XID = 0;

        //Numero economico para almacenar
        public static String no_activo;

        //Existe_Usuario cargar XML repetidos
        public static Boolean usuario_en_xml = false;
        public static String usuario_en_xml_nombre = "";


        public static String Buscar_economico(String noserie)
        {
            no_activo = "S/N";
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(database.nsqlExSirac))
                {
                    conexion2.Open();
                    String sql2 = "SELECT * FROM [bd_SiRAc].[dbo].[LNJ_Equipos_Gilberto] where [No. Serie]='" + noserie + "'";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    while (nwReader2.Read())
                    {
                        no_activo = nwReader2["No. Activo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                no_activo = "S/N";
            }
            return no_activo;
        }

        public static void Cargar(String NM, String Marca, String Modelo, String Tipo, String Ram, String ddt, String ddl, String so, String procesador,
                                     String arquitectura, String numserie, String Depa, String localidad, String Usuario, String licenciaso, String empresa,
                                     String fechainicio, String fechatermino, String horainicio, String horatermino, String observaciones, int mantenimiento)
        {
            /*
             * 
             * 
             *  VERIFICA NUMERO ECONOMICO
             * 
             */


            try
            {
                using (SqlConnection conexion2 = new SqlConnection(database.nsqlExSirac))
                {
                    conexion2.Open();
                    String sql2 = "SELECT * FROM [bd_SiRAc].[dbo].[LNJ_Equipos_Gilberto] where [No. Serie]='"+numserie+"'";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    while (nwReader2.Read())
                    {
                        no_activo = nwReader2["No. Activo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la busqueda\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(string.IsNullOrEmpty(no_activo))
            {
                NumActivo form = new NumActivo();
                form.ShowDialog();
            }

            /*
             * 
             * 
             *  INSERTA TODOS LOS DATOS EN LA DB
             * 
             */
            try
            {
                //String nombresqlexpress = "server=" + servidor + "; database=" + basededatos + " ; integrated security = true ; MultipleActiveResultSets=True";
                using (SqlConnection conexion = new SqlConnection(nombresqlexpress))
                {
                    conexion.Open();


                    string usernameequipo = Data.funcion_wmi("Win32_ComputerSystem", "UserName");
                    string[] usuario_word = usernameequipo.Split('\\');

                    //Console.WriteLine("Usuario: " + Orden.namepc_2 + "\\" + usuario_word[1]);

                    string sqlIns = "INSERT INTO " + tablabase + " (uid, nombreequipo, marca, modelo, usuario, tipo, ram, ddtotal, ddlibre, so, licenciaso, procesador, " +
                            "arquitectura, numeroserie, empresa, departamento, base, nombre, fechainicio, fechatermino, horainicio, horatermino, fecha, hora, mes, year, observaciones, noactivo, mantenimiento)" +
                            " VALUES (@uid, @name, @marca, @modelo, @usuario, @tipo, @ram, @ddtotal, @ddlibre, @so, @licenciaso, @procesador, @arquitectura, @numeroserie, @empresa, " +
                            "@departamento, @base, @nombre, @fechainicio, @fechatermino, @horainicio, @horatermino, @fecha, @hora, @mes, @year, @observaciones, @noactivo, @tipomantenimiento)";
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conexion);
                    cmdIns.Parameters.Add("@uid", useruid);
                    cmdIns.Parameters.Add("@name", NM);
                    cmdIns.Parameters.Add("@marca", Marca);
                    cmdIns.Parameters.Add("@modelo", Modelo);

                    if (usuario_en_xml == true)
                    {
                        cmdIns.Parameters.Add("@usuario",usuario_en_xml_nombre );
                    }
                    else
                    {
                        cmdIns.Parameters.Add("@usuario", Orden.namepc_2 + "\\" + usuario_word[1]);
                    }
                    cmdIns.Parameters.Add("@tipo", Tipo);
                    cmdIns.Parameters.Add("@ram", Ram);
                    cmdIns.Parameters.Add("@so", so);
                    cmdIns.Parameters.Add("@licenciaso", licenciaso);
                    cmdIns.Parameters.Add("@procesador", procesador);
                    cmdIns.Parameters.Add("@arquitectura", arquitectura);
                    cmdIns.Parameters.Add("@numeroserie", numserie);
                    cmdIns.Parameters.Add("@empresa", empresa);
                    cmdIns.Parameters.Add("@fecha", DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                    cmdIns.Parameters.Add("@hora", DateTime.Now.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                    cmdIns.Parameters.Add("@ddtotal", ddt);
                    cmdIns.Parameters.Add("@ddlibre", ddl);
                    cmdIns.Parameters.Add("@departamento", Depa);
                    cmdIns.Parameters.Add("@base", localidad);
                    cmdIns.Parameters.Add("@nombre", Usuario);
                    cmdIns.Parameters.Add("@fechainicio", fechainicio);
                    cmdIns.Parameters.Add("@horainicio", horainicio);
                    cmdIns.Parameters.Add("@fechatermino", fechatermino);
                    cmdIns.Parameters.Add("@horatermino", horatermino);
                    cmdIns.Parameters.Add("@observaciones", observaciones);
                    cmdIns.Parameters.Add("@tipomantenimiento", mantenimiento);

                    no_activo = (String.IsNullOrEmpty(no_activo)) ? "S/N": no_activo;
                    cmdIns.Parameters.Add("@noactivo", no_activo);

                    string[] words = fechainicio.Split('/');

                    cmdIns.Parameters.Add("@mes", DateTime.Now.ToString(words[1], CultureInfo.InvariantCulture));
                    cmdIns.Parameters.Add("@year", DateTime.Now.ToString(words[2], CultureInfo.InvariantCulture));


                    /*
                     *      CARGA DE
                     *      INFORMACION PARA
                     *      ENTREGA DE EQUIPOS NUEVOS
                     *      
                     *      BASE DE DATOS COMPRASEQCOMPUTO
                     *      
                     */
                    try
                    {
                        using (SqlConnection conexion2 = new SqlConnection(nombresqlexpress))
                        {
                            conexion2.Open();
                            SqlCommand comm2 = new SqlCommand("SELECT * FROM [InfEq].[dbo].[ComprasEqComputo] where economico='"+ no_activo + "' AND entregada='0'", conexion2);
                            SqlDataReader nwReader2 = comm2.ExecuteReader();
                            while (nwReader2.Read())
                            {
                                String insert = "UPDATE ComprasEqComputo SET stock_disponible=@stock_disponible, entregada=@entregada, nombre_entrega=@nombre_entrega " +
                                "WHERE cid='" + nwReader2["cid"].ToString() + "'";

                                SqlCommand cmdIns_update = new SqlCommand(insert, conexion2);

                                cmdIns_update.Parameters.AddWithValue("@stock_disponible", "0");
                                cmdIns_update.Parameters.AddWithValue("@entregada", "1");
                                cmdIns_update.Parameters.AddWithValue("@nombre_entrega", Usuario);

                                cmdIns_update.ExecuteNonQuery();
                                cmdIns_update.Parameters.Clear();

                                cmdIns_update.Dispose();
                                cmdIns_update = null;
                                break;
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Error al actualizar pendiente de compra .\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    /*
                     *      AQUI TERMINA
                     *      LA CARGA
                     */



                    cmdIns.ExecuteNonQuery();

                    cmdIns.Parameters.Clear();
                    cmdIns.CommandText = "SELECT @@IDENTITY";

                    int insertID = Convert.ToInt32(cmdIns.ExecuteScalar());
                    IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface adapter in nics)
                    {
                        String mac = string.Join(":", (from z in adapter.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());
                        mac = string.IsNullOrEmpty(mac) ? "Sin Datos" : mac;

                        string sqlInsMac = "INSERT INTO " + tablabasemacs + " (xid, Nombre, Address) VALUES (@xid, @nombremac, @macinterfas)";
                        SqlCommand cmdInsMac = new SqlCommand(sqlInsMac, conexion);
                        cmdInsMac.Parameters.Add("@xid", insertID);
                        cmdInsMac.Parameters.Add("@nombremac", adapter.Description.ToString());
                        cmdInsMac.Parameters.Add("@macinterfas", mac);
                        cmdInsMac.ExecuteNonQuery();

                        cmdInsMac.Parameters.Clear();
                        cmdInsMac.CommandText = "SELECT @@IDENTITY";
                        cmdInsMac.Dispose();
                        cmdInsMac = null;
                    }

                    cmdIns.Dispose();
                    cmdIns = null;

                    usuario_en_xml = false;
                    MessageBox.Show("Información cargada correctamente.\n\nId de la información: "+ insertID, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Deshabilita boton de carga de informacion
                    //botoncargar = false;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al cargar la información. \n\nMensaje: " + e.Message, "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Error);
                botoncargar = true;
            }
        }


        
        /*
         * 
         * 
         * 
         * 
         * 
         * 
         *          funcion para cargar varios XML desde panel admin
         *         
         *         
         *         
         *         
         *         
         *         
         */
        public static void CargarPanelAdmin(String NM, String Marca, String Modelo, String Userlogin, String Tipo, String Ram, String ddt, String ddl, String so, String licenciaso, 
                                    String procesador, String arquitectura, String numserie, String empresa, String Depa, String localidad, String Usuario, 
                                    String fechainicio, String fechatermino, String horainicio, String horatermino, String fecha, String hora,
                                    String mes, String year, String observaciones, String idmac, String mantenimiento)
        {
            /*
             * 
             * 
             *  VERIFICA NUMERO ECONOMICO
             * 
             */


            try
            {
                using (SqlConnection conexion2 = new SqlConnection(database.nsqlExSirac))
                {
                    conexion2.Open();
                    String sql2 = "SELECT * FROM [bd_SiRAc].[dbo].[LNJ_Equipos_Gilberto] where [No. Serie]='" + numserie + "'";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    while (nwReader2.Read())
                    {
                        no_activo = nwReader2["No. Activo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la busqueda\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (string.IsNullOrEmpty(no_activo))
            {
                NumActivo form = new NumActivo();
                form.ShowDialog();
            }

            try
            {

                //String nombresqlexpress = "server=" + servidor + "; database=" + basededatos + " ; integrated security = true ; MultipleActiveResultSets=True";
                using (SqlConnection conexion = new SqlConnection(nombresqlexpress))
                {
                    conexion.Open();
                    string sqlIns = "INSERT INTO " + tablabase + " (uid, nombreequipo, marca, modelo, usuario, tipo, ram, ddtotal, ddlibre, so, licenciaso, procesador, " +
                            "arquitectura, numeroserie, empresa, departamento, base, nombre, fechainicio, fechatermino, horainicio, horatermino, fecha, hora, mes, year, observaciones, noactivo, mantenimiento)" +
                            " VALUES (@uid, @name, @marca, @modelo, @usuario, @tipo, @ram, @ddtotal, @ddlibre, @so, @licenciaso, @procesador, @arquitectura, @numeroserie, @empresa, " +
                            "@departamento, @base, @nombre, @fechainicio, @fechatermino, @horainicio, @horatermino, @fecha, @hora, @mes, @year, @observaciones, @noactivo, @tipomantenimiento)";
                    SqlCommand cmdIns = new SqlCommand(sqlIns, conexion);
                    cmdIns.Parameters.Add("@uid", useruid);
                    cmdIns.Parameters.Add("@name", NM);
                    cmdIns.Parameters.Add("@marca", Marca);
                    cmdIns.Parameters.Add("@modelo", Modelo);
                    cmdIns.Parameters.Add("@usuario", Userlogin);
                    cmdIns.Parameters.Add("@tipo", Tipo);
                    cmdIns.Parameters.Add("@ram", Ram);
                    cmdIns.Parameters.Add("@so", so);
                    cmdIns.Parameters.Add("@licenciaso", licenciaso);
                    cmdIns.Parameters.Add("@procesador", procesador);
                    cmdIns.Parameters.Add("@arquitectura", arquitectura);
                    cmdIns.Parameters.Add("@numeroserie", numserie);
                    cmdIns.Parameters.Add("@empresa", empresa);
                    cmdIns.Parameters.Add("@fecha", fecha);
                    cmdIns.Parameters.Add("@hora", hora);
                    cmdIns.Parameters.Add("@ddtotal", ddt);
                    cmdIns.Parameters.Add("@ddlibre", ddl);
                    cmdIns.Parameters.Add("@departamento", Depa);
                    cmdIns.Parameters.Add("@base", localidad);
                    cmdIns.Parameters.Add("@nombre", Usuario);
                    cmdIns.Parameters.Add("@fechainicio", fechainicio);
                    cmdIns.Parameters.Add("@horainicio", horainicio);
                    cmdIns.Parameters.Add("@fechatermino", fechatermino);
                    cmdIns.Parameters.Add("@horatermino", horatermino);
                    cmdIns.Parameters.Add("@observaciones", observaciones);
                    cmdIns.Parameters.Add("@mes", mes);
                    cmdIns.Parameters.Add("@year", year);

                    cmdIns.Parameters.Add("@tipomantenimiento", mantenimiento);

                    no_activo = (String.IsNullOrEmpty(no_activo)) ? "S/N" : no_activo;
                    cmdIns.Parameters.Add("@noactivo", no_activo);

                    cmdIns.ExecuteNonQuery();

                    cmdIns.Parameters.Clear();
                    cmdIns.CommandText = "SELECT @@IDENTITY";

                    int insertID = Convert.ToInt32(cmdIns.ExecuteScalar());


                    int iii = 1;
                    do
                    {
                        string sqlInsMac = "INSERT INTO " + tablabasemacs + " (xid, Nombre, Address) VALUES (@xid, @nombremac, @macinterfas)";
                        SqlCommand cmdInsMac = new SqlCommand(sqlInsMac, conexion);
                        cmdInsMac.Parameters.Add("@xid", insertID);
                        cmdInsMac.Parameters.Add("@nombremac", SubirXML.maqs[Convert.ToInt32(idmac), iii, 0]);
                        cmdInsMac.Parameters.Add("@macinterfas", SubirXML.maqs[Convert.ToInt32(idmac), iii, 1]);
                        cmdInsMac.ExecuteNonQuery();

                        cmdInsMac.Parameters.Clear();
                        cmdInsMac.CommandText = "SELECT @@IDENTITY";
                        cmdInsMac.Dispose();
                        cmdInsMac = null;

                        iii++;
                    } while (iii <= Convert.ToInt32(SubirXML.maqs[Convert.ToInt32(Convert.ToInt32(idmac)), 0, 0]));
                    
                    cmdIns.Dispose();
                    cmdIns = null;
                    MessageBox.Show("Equipo "+NM+" cargado correctamente.\n\nId de la información: " + insertID, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar la información de "+NM+". \n\nMensaje: " + e.Message, "InfEq", MessageBoxButtons.OK, MessageBoxIcon.Error);
                botoncargar = true;
            }
        }

        public static string EncriptarPass(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static bool EsAdministrador()
        {
            Thread.GetDomain().SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            WindowsPrincipal myUser = (WindowsPrincipal)Thread.CurrentPrincipal;
            return myUser.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
