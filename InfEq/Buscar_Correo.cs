using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace InfEq
{
    public partial class Buscar_Correo : Form
    {
        #region SQL
        //public static String select = "SELECT ltrim(rtrim(nombre)) as nombre, ltrim(rtrim(apepat)) as paterno, ltrim(rtrim(apemat)) as materno,email FROM [Nom2001].[dbo].[nomtrab] where status='A' ORDER BY Nombre asc";
        /*
        public static String select = "SELECT ltrim(rtrim(nombre)) as nombre, ltrim(rtrim(apepat)) as paterno, ltrim(rtrim(apemat)) as materno,email, ISNULL(nompais.despai,'') AS [ubicacion],ISNULL(CC.desubi,'') AS [cc]" +
            "FROM nomtrab " +
            "LEFT JOIN nomubic CC ON nomtrab.cvepa2 = CC.cvepai AND nomtrab.cveci2 = CC.cveciu AND nomtrab.cvecia = CC.cvecia AND nomtrab.cveubi = CC.cveubi " +
            "LEFT JOIN nompais ON nomtrab.cvepa2 = nompais.cvepai AND nomtrab.cvecia = nompais.cvecia " +
            "WHERE nomtrab.status= 'A'";
        */
        public static String select = "SELECT Ltrim(Rtrim(nombre))       AS nombre,        Ltrim(Rtrim(apepat))       AS paterno,        Ltrim(Rtrim(apemat))       AS materno,        Isnull(nompais.despai, '') AS [ubicacion],        Isnull(CC.desubi, '')      AS [cc],        Ltrim(Rtrim(nomtrab.email)) AS email,        Ltrim(Rtrim(nomcias.descor)) AS empresa " +
            "FROM   nomtrab        LEFT JOIN nomubic CC               ON nomtrab.cvepa2 = CC.cvepai                  AND nomtrab.cveci2 = CC.cveciu                  AND nomtrab.cvecia = CC.cvecia                  AND nomtrab.cveubi = CC.cveubi 	   LEFT JOIN nomcias               ON nomtrab.cvecia = nomcias.cvecia        " +
            "LEFT JOIN nompais                ON nomtrab.cvepa2 = nompais.cvepai                  AND nomtrab.cvecia = nompais.cvecia " +
            "WHERE  nomtrab.status = 'A' ";
        public static String conexionsql = "server=40.76.105.1,5055; database=Nom2001;User ID=reportesUNNE;Password=8rt=h!RdP9gVy; integrated security = false ; MultipleActiveResultSets=True";
        #endregion


        public static Boolean descargar = false;
        public static List<String[]> empleados = new List<String[]>();
        public Buscar_Correo()
        {
            InitializeComponent();
        }

        public static String CorreoCampo;
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                {
                    conexion.Open();
                    String sql = "SELECT * FROM " + database.tablabase + " WHERE XID='"+Buscar.ID+"'";
                    SqlCommand comm = new SqlCommand(sql, conexion);
                    SqlDataReader nwReader = comm.ExecuteReader();
                    while (nwReader.Read())
                    {
                        Orden.Usuario = nwReader["nombre"].ToString();
                        Orden.empresa2 = nwReader["empresa"].ToString();
                        Orden.base2 = nwReader["base"].ToString();
                        Orden.depa2 = nwReader["departamento"].ToString();
                        Orden.Tipo = nwReader["tipo"].ToString();
                        Orden.Marca = nwReader["marca"].ToString();
                        Orden.Modelo = nwReader["modelo"].ToString();
                        Orden.NumerodeSerie = nwReader["numeroserie"].ToString();
                        Orden.fecha_inicio = nwReader["fechainicio"].ToString();
                        Orden.hora_inicio = nwReader["horainicio"].ToString();
                        Orden.fecha_termino = nwReader["fechatermino"].ToString();
                        Orden.hora_termino = nwReader["horatermino"].ToString();
                        Orden.observaciones2 = nwReader["observaciones"].ToString();
                        Orden.correoelectronico = correo.Text;
                        CorreoCampo = correo.Text;

                        CrearPDF imprimir = new CrearPDF();
                        imprimir.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la busqueda\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscar_Correo_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(orden, "Enviar orden de mantenimiento realizado");
            toolTip2.SetToolTip(resguardo, "Enviar correo para pasar activos por el equipo");

            if(!empleados.Any())
            {
                CargandoEmpleados CargandoEmpleados = new CargandoEmpleados();
                CargandoEmpleados.ShowDialog();
            }

            Boolean existedato = false;
            foreach(String[] emp in empleados)
            {
                if(emp[3].ToUpper() == Buscar.nombrecorreo.ToUpper())
                {
                    existedato = true;
                    correo.Text = emp[6];
                }
            }
            if(!existedato)
            {
                MessageBox.Show("No existe el usuario " + Buscar.nombrecorreo + " en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            String nombrespl = Buscar.nombrecorreo;
            String[] nombres = nombrespl.Split(' ');
            try
            {
                nombre.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombres[0].ToLower());
            }
            catch (Exception ex)
            {
                nombre.Text = "";
            }
            activo.Text = Buscar.activocorreo;
            marca.Text = Buscar.marcaactivo;
            modelo.Text = Buscar.modeloactivo;
            serie.Text = Buscar.nserieactivo;
        }

        private void Orden_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            descargar = false;

            if (!String.IsNullOrEmpty(correo.Text))
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(database.nombresqlexpress))
                    {
                        conexion.Open();
                        String sql = "SELECT * FROM " + database.tablabase + " WHERE XID='" + Buscar.ID + "'";
                        SqlCommand comm = new SqlCommand(sql, conexion);
                        SqlDataReader nwReader = comm.ExecuteReader();
                        while (nwReader.Read())
                        {
                            Orden.Usuario = nwReader["nombre"].ToString();
                            Orden.empresa2 = nwReader["empresa"].ToString();
                            Orden.base2 = nwReader["base"].ToString();
                            Orden.depa2 = nwReader["departamento"].ToString();
                            Orden.Tipo = nwReader["tipo"].ToString();
                            Orden.Marca = nwReader["marca"].ToString();
                            Orden.Modelo = nwReader["modelo"].ToString();
                            Orden.NumerodeSerie = nwReader["numeroserie"].ToString();
                            Orden.fecha_inicio = nwReader["fechainicio"].ToString();
                            Orden.hora_inicio = nwReader["horainicio"].ToString();
                            Orden.fecha_termino = nwReader["fechatermino"].ToString();
                            Orden.hora_termino = nwReader["horatermino"].ToString();
                            Orden.observaciones2 = nwReader["observaciones"].ToString();
                            Orden.correoelectronico = correo.Text;
                            CorreoCampo = correo.Text;


                            CrearPDF.archivo = nwReader["tipo"].ToString() + "_" + nwReader["nombreequipo"].ToString() + "_" + nwReader["numeroserie"].ToString() + ".pdf";

                            CrearPDF imprimir = new CrearPDF();
                            imprimir.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar correo\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar un correo electronico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        Saltar:
            this.Enabled = true;
            Close();
        }

        private void Resguardo_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(correo.Text))
            {
                try
                {
                    List<string> lstAllRecipients = new List<string>();
                    //Below is hardcoded - can be replaced with db data
                    lstAllRecipients.Add(correo.Text);

                    Outlook.Application outlookApp = new Outlook.Application();
                    Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                    Outlook.Inspector oInspector = oMailItem.GetInspector;

                    // Recipient
                    Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
                    foreach (String recipient in lstAllRecipients)
                    {
                        Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                        oRecip.Resolve();
                    }

                    //Add CC -- (carga correo de copia TI)
                    Outlook.Recipient oCCRecip = oRecips.Add(database.view_conf_correo_ti);
                    oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
                    oCCRecip.Resolve();

                    //Carga copia a activos fijos
                    Outlook.Recipient oCCRecip2 = oRecips.Add(database.view_conf_correo_af);
                    oCCRecip2.Type = (int)Outlook.OlMailRecipientType.olCC;
                    oCCRecip2.Resolve();
                    /*
                    Outlook.Recipient oCCRecip3 = oRecips.Add("octavio.alvarez@unne.com.mx");
                    oCCRecip3.Type = (int)Outlook.OlMailRecipientType.olCC;
                    oCCRecip3.Resolve();
                    */
                    

                    //Add Subject
                    String asunto = (String.Equals(Buscar.tipoactivo,"CPU")) ? "PC" : "laptop";
                    oMailItem.Subject = "Resguardo de " + asunto;

                    String tt = oMailItem.HTMLBody;
                    // body, bcc etc...
                    oMailItem.HTMLBody = "<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" xmlns:m=\"http://schemas.microsoft.com/office/2004/12/omml\" xmlns=\"http://www.w3.org/TR/REC-html40\"><head><meta http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\"><meta name=Generator content=\"Microsoft Word 15 (filtered medium)\"><style><!--/* Font Definitions */@font-face	{font-family:Wingdings;	panose-1:5 0 0 0 0 0 0 0 0 0;}@font-face	{font-family:\"Cambria Math\";	panose-1:2 4 5 3 5 4 6 3 2 4;}@font-face	{font-family:Calibri;	panose-1:2 15 5 2 2 2 4 3 2 4;}/* Style Definitions */p.MsoNormal, li.MsoNormal, div.MsoNormal	{margin:0cm;	margin-bottom:.0001pt;	font-size:11.0pt;	font-family:\"Calibri\",sans-serif;	mso-fareast-language:EN-US;}a:link, span.MsoHyperlink	{mso-style-priority:99;	color:#0563C1;	text-decoration:underline;}a:visited, span.MsoHyperlinkFollowed	{mso-style-priority:99;	color:#954F72;	text-decoration:underline;}p.MsoListParagraph, li.MsoListParagraph, div.MsoListParagraph	{mso-style-priority:34;	margin-top:0cm;	margin-right:0cm;	margin-bottom:0cm;	margin-left:36.0pt;	margin-bottom:.0001pt;	font-size:11.0pt;	font-family:\"Calibri\",sans-serif;	mso-fareast-language:EN-US;}span.EstiloCorreo17	{mso-style-type:personal-compose;	font-family:\"Calibri\",sans-serif;	color:#2F5496;}.MsoChpDefault	{mso-style-type:export-only;	font-family:\"Calibri\",sans-serif;	mso-fareast-language:EN-US;}@page WordSection1	{size:612.0pt 792.0pt;	margin:70.85pt 3.0cm 70.85pt 3.0cm;}div.WordSection1	{page:WordSection1;}/* List Definitions */@list l0	{mso-list-id:63528328;	mso-list-type:hybrid;	mso-list-template-ids:229288886 134873089 134873091 134873093 134873089 134873091 134873093 134873089 134873091 134873093;}@list l0:level1	{mso-level-number-format:bullet;	mso-level-text:\\F0B7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Symbol;}@list l0:level2	{mso-level-number-format:bullet;	mso-level-text:o;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:\"Courier New\";}@list l0:level3	{mso-level-number-format:bullet;	mso-level-text:\\F0A7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Wingdings;}@list l0:level4	{mso-level-number-format:bullet;	mso-level-text:\\F0B7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Symbol;}@list l0:level5	{mso-level-number-format:bullet;	mso-level-text:o;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:\"Courier New\";}@list l0:level6	{mso-level-number-format:bullet;	mso-level-text:\\F0A7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Wingdings;}@list l0:level7	{mso-level-number-format:bullet;	mso-level-text:\\F0B7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Symbol;}@list l0:level8	{mso-level-number-format:bullet;	mso-level-text:o;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:\"Courier New\";}@list l0:level9	{mso-level-number-format:bullet;	mso-level-text:\\F0A7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Wingdings;}@list l1	{mso-list-id:378863993;	mso-list-type:hybrid;	mso-list-template-ids:1531854090 134873089 134873091 134873093 134873089 134873091 134873093 134873089 134873091 134873093;}@list l1:level1	{mso-level-number-format:bullet;	mso-level-text:\\F0B7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Symbol;}@list l1:level2	{mso-level-number-format:bullet;	mso-level-text:o;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:\"Courier New\";}@list l1:level3	{mso-level-number-format:bullet;	mso-level-text:\\F0A7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Wingdings;}@list l1:level4	{mso-level-number-format:bullet;	mso-level-text:\\F0B7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Symbol;}@list l1:level5	{mso-level-number-format:bullet;	mso-level-text:o;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:\"Courier New\";}@list l1:level6	{mso-level-number-format:bullet;	mso-level-text:\\F0A7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Wingdings;}@list l1:level7	{mso-level-number-format:bullet;	mso-level-text:\\F0B7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Symbol;}@list l1:level8	{mso-level-number-format:bullet;	mso-level-text:o;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:\"Courier New\";}@list l1:level9	{mso-level-number-format:bullet;	mso-level-text:\\F0A7;	mso-level-tab-stop:none;	mso-level-number-position:left;	text-indent:-18.0pt;	font-family:Wingdings;}ol	{margin-bottom:0cm;}ul	{margin-bottom:0cm;}--></style><!--[if gte mso 9]><xml><o:shapedefaults v:ext=\"edit\" spidmax=\"1026\" /></xml><![endif]--><!--[if gte mso 9]><xml><o:shapelayout v:ext=\"edit\"><o:idmap v:ext=\"edit\" data=\"1\" /></o:shapelayout></xml><![endif]--></head><body lang=ES-MX link=\"#0563C1\" vlink=\"#954F72\"><div class=WordSection1><p class=MsoNormal><span style='color:#2F5496'>" + nombre.Text + " favor de pasar a activos para que te hagan entrega del siguiente equipo de cómputo, una vez que cuentes con el favor de levantar un SiTTi (<a href=\"http://148.223.153.43/SiTTi\">http://148.223.153.43/SiTTi</a>) para la configuración, respaldo de información y entrega del equipo actual.<o:p></o:p></span></p><p class=MsoNormal><span style='color:#2F5496'><o:p>&nbsp;</o:p></span></p><p class=MsoListParagraph style='text-indent:-18.0pt;mso-list:l0 level1 lfo2'><![if !supportLists]><span style='font-family:Symbol;color:#2F5496'><span style='mso-list:Ignore'>·<span style='font:7.0pt \"Times New Roman\"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><b><span style='color:#2F5496;mso-fareast-language:ES-MX'>Tipo:</span></b><span style='color:#2F5496;mso-fareast-language:ES-MX'> " + Buscar.tipoactivo + "</span><span style='color:#2F5496'><o:p></o:p></span></p><p class=MsoListParagraph style='text-indent:-18.0pt;mso-list:l0 level1 lfo2'><![if !supportLists]><span style='font-family:Symbol;color:#2F5496'><span style='mso-list:Ignore'>·<span style='font:7.0pt \"Times New Roman\"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><b><span style='color:#2F5496;mso-fareast-language:ES-MX'>Núm. De Activo:</span></b><span style='color:#2F5496;mso-fareast-language:ES-MX'> " + activo.Text + "</span><span style='color:#2F5496'><o:p></o:p></span></p><p class=MsoListParagraph style='text-indent:-18.0pt;mso-list:l0 level1 lfo2'><![if !supportLists]><span style='font-family:Symbol;color:#2F5496'><span style='mso-list:Ignore'>·<span style='font:7.0pt \"Times New Roman\"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><b><span style='color:#2F5496;mso-fareast-language:ES-MX'>Marca:</span></b><span style='color:#2F5496;mso-fareast-language:ES-MX'> " + marca.Text + "</span><span style='color:#2F5496'><o:p></o:p></span></p><p class=MsoListParagraph style='text-indent:-18.0pt;mso-list:l0 level1 lfo2'><![if !supportLists]><span style='font-family:Symbol;color:#2F5496'><span style='mso-list:Ignore'>·<span style='font:7.0pt \"Times New Roman\"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><b><span style='color:#2F5496;mso-fareast-language:ES-MX'>Modelo:</span></b><span style='color:#2F5496;mso-fareast-language:ES-MX'> " + modelo.Text + "</span><span style='color:#2F5496'><o:p></o:p></span></p><p class=MsoListParagraph style='text-indent:-18.0pt;mso-list:l0 level1 lfo2'><![if !supportLists]><span style='font-family:Symbol;color:#2F5496'><span style='mso-list:Ignore'>·<span style='font:7.0pt \"Times New Roman\"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><b><span style='color:#2F5496;mso-fareast-language:ES-MX'>Número de Serie:</span></b><span style='color:#2F5496;mso-fareast-language:ES-MX'> " + serie.Text + "</span><span style='color:#2F5496'><o:p></o:p></span></p></div>";
                    oMailItem.HTMLBody += tt;

                    //Display the mailbox
                    oMailItem.Display(true);
                }
                catch (Exception objEx)
                {
                    MessageBox.Show("Error al abrir outlook\nError: "+objEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar un correo electronico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void correo_DoubleClick(object sender, EventArgs e)
        {
            correo.Text = "edson.ordaz@unne.com.mx";
        }
    }
}
