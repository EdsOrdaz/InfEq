namespace InfEq
{
    partial class Buscar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Buscar));
            this.empresa = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.localidad = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.depa = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.marca = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.modelo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.serialnumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.procesador = new System.Windows.Forms.TextBox();
            this.so = new System.Windows.Forms.TextBox();
            this.namemachine = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.ComboBox();
            this.mes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolregresar = new System.Windows.Forms.ToolTip(this.components);
            this.toolexportar = new System.Windows.Forms.ToolTip(this.components);
            this.tooldetalle = new System.Windows.Forms.ToolTip(this.components);
            this.toolreset = new System.Windows.Forms.ToolTip(this.components);
            this.activo = new System.Windows.Forms.TextBox();
            this.equipos = new System.Windows.Forms.DataGridView();
            this.ids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noactivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreequipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ram1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddtotal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddlibre1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.so1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.licenciaso1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procesador1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arquitectura1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroserie1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresa1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departamento1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechainicio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horainicio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechatermino1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horatermino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.macaddress = new System.Windows.Forms.DataGridViewButtonColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bwexcel = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.reset = new System.Windows.Forms.Button();
            this.regresar = new System.Windows.Forms.Button();
            this.exportarexcel = new System.Windows.Forms.Button();
            this.buscardetalle = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.mac = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.mtto2 = new System.Windows.Forms.ComboBox();
            this.mttolabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.equipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // empresa
            // 
            this.empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empresa.FormattingEnabled = true;
            this.empresa.Items.AddRange(new object[] {
            "NINGUNA",
            "TRACSA",
            "DICOMEX",
            "ETE",
            "TECS",
            "EXPROMAT",
            "PAME",
            "TRAFESA"});
            this.empresa.Location = new System.Drawing.Point(16, 106);
            this.empresa.Name = "empresa";
            this.empresa.Size = new System.Drawing.Size(162, 24);
            this.empresa.TabIndex = 11;
            this.empresa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Empresa_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 20);
            this.label17.TabIndex = 65;
            this.label17.Text = "Empresa";
            // 
            // usuario
            // 
            this.usuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario.Location = new System.Drawing.Point(880, 64);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(210, 22);
            this.usuario.TabIndex = 10;
            this.usuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Usuario_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(876, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 20);
            this.label14.TabIndex = 64;
            this.label14.Text = "Usuario";
            // 
            // localidad
            // 
            this.localidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.localidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localidad.Location = new System.Drawing.Point(664, 64);
            this.localidad.Name = "localidad";
            this.localidad.Size = new System.Drawing.Size(210, 22);
            this.localidad.TabIndex = 9;
            this.localidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Localidad_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(660, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 20);
            this.label13.TabIndex = 63;
            this.label13.Text = "Base";
            // 
            // depa
            // 
            this.depa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.depa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depa.Location = new System.Drawing.Point(448, 64);
            this.depa.Name = "depa";
            this.depa.Size = new System.Drawing.Size(210, 22);
            this.depa.TabIndex = 8;
            this.depa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Depa_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(444, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 20);
            this.label11.TabIndex = 62;
            this.label11.Text = "Departamento";
            // 
            // marca
            // 
            this.marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marca.Location = new System.Drawing.Point(232, 20);
            this.marca.Name = "marca";
            this.marca.Size = new System.Drawing.Size(210, 22);
            this.marca.TabIndex = 2;
            this.marca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Marca_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(228, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 20);
            this.label10.TabIndex = 57;
            this.label10.Text = "Marca";
            // 
            // modelo
            // 
            this.modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelo.Location = new System.Drawing.Point(448, 20);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(210, 22);
            this.modelo.TabIndex = 3;
            this.modelo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Modelo_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(444, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 56;
            this.label9.Text = "Modelo";
            // 
            // serialnumber
            // 
            this.serialnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialnumber.Location = new System.Drawing.Point(232, 64);
            this.serialnumber.Name = "serialnumber";
            this.serialnumber.Size = new System.Drawing.Size(210, 22);
            this.serialnumber.TabIndex = 7;
            this.serialnumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Serialnumber_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(228, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 20);
            this.label8.TabIndex = 55;
            this.label8.Text = "Numero de Serie";
            // 
            // procesador
            // 
            this.procesador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.procesador.Location = new System.Drawing.Point(880, 20);
            this.procesador.Name = "procesador";
            this.procesador.Size = new System.Drawing.Size(210, 22);
            this.procesador.TabIndex = 6;
            this.procesador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Procesador_KeyDown);
            // 
            // so
            // 
            this.so.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.so.Location = new System.Drawing.Point(664, 20);
            this.so.Name = "so";
            this.so.Size = new System.Drawing.Size(210, 22);
            this.so.TabIndex = 5;
            this.so.TextChanged += new System.EventHandler(this.So_TextChanged);
            this.so.KeyDown += new System.Windows.Forms.KeyEventHandler(this.So_KeyDown);
            // 
            // namemachine
            // 
            this.namemachine.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.namemachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namemachine.Location = new System.Drawing.Point(16, 20);
            this.namemachine.Name = "namemachine";
            this.namemachine.Size = new System.Drawing.Size(210, 22);
            this.namemachine.TabIndex = 1;
            this.namemachine.TextChanged += new System.EventHandler(this.Namemachine_TextChanged);
            this.namemachine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Namemachine_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 49;
            this.label7.Text = "Num. Activo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(876, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Procesador";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(660, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "Sistema Operativo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "Nombre del Equipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(186, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 66;
            this.label1.Text = "Tipo";
            // 
            // tipo
            // 
            this.tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipo.FormattingEnabled = true;
            this.tipo.Items.AddRange(new object[] {
            "NINGUNO",
            "LAPTOP",
            "CPU"});
            this.tipo.Location = new System.Drawing.Point(190, 106);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(162, 24);
            this.tipo.TabIndex = 12;
            this.tipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tipo_KeyDown);
            // 
            // mes
            // 
            this.mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mes.FormattingEnabled = true;
            this.mes.Items.AddRange(new object[] {
            "NINGUNO",
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SEPTIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.mes.Location = new System.Drawing.Point(365, 106);
            this.mes.Name = "mes";
            this.mes.Size = new System.Drawing.Size(162, 24);
            this.mes.TabIndex = 13;
            this.mes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mes_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(361, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 68;
            this.label2.Text = "Mes";
            // 
            // year
            // 
            this.year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.year.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year.FormattingEnabled = true;
            this.year.Items.AddRange(new object[] {
            "NINGUNO",
            "2018",
            "2019",
            "2020",
            "2021"});
            this.year.Location = new System.Drawing.Point(539, 106);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(162, 24);
            this.year.TabIndex = 14;
            this.year.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Year_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(539, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 70;
            this.label3.Text = "Año";
            // 
            // activo
            // 
            this.activo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activo.Location = new System.Drawing.Point(16, 64);
            this.activo.Name = "activo";
            this.activo.Size = new System.Drawing.Size(210, 22);
            this.activo.TabIndex = 76;
            this.activo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Activo_KeyDown);
            // 
            // equipos
            // 
            this.equipos.AllowUserToAddRows = false;
            this.equipos.AllowUserToDeleteRows = false;
            this.equipos.AllowUserToOrderColumns = true;
            this.equipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ids,
            this.noactivo,
            this.nombreequipo,
            this.marca1,
            this.modelo1,
            this.usuario1,
            this.mtto,
            this.tipo1,
            this.ram1,
            this.ddtotal1,
            this.ddlibre1,
            this.so1,
            this.licenciaso1,
            this.procesador1,
            this.arquitectura1,
            this.numeroserie1,
            this.empresa1,
            this.base1,
            this.departamento1,
            this.nombre1,
            this.fechainicio1,
            this.horainicio1,
            this.fechatermino1,
            this.horatermino,
            this.observaciones1,
            this.macaddress});
            this.equipos.EnableHeadersVisualStyles = false;
            this.equipos.Location = new System.Drawing.Point(2, 134);
            this.equipos.Name = "equipos";
            this.equipos.ReadOnly = true;
            this.equipos.Size = new System.Drawing.Size(1089, 432);
            this.equipos.TabIndex = 77;
            this.equipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // ids
            // 
            this.ids.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ids.HeaderText = "ID";
            this.ids.Name = "ids";
            this.ids.ReadOnly = true;
            this.ids.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ids.Width = 43;
            // 
            // noactivo
            // 
            this.noactivo.HeaderText = "No. Activo";
            this.noactivo.Name = "noactivo";
            this.noactivo.ReadOnly = true;
            // 
            // nombreequipo
            // 
            this.nombreequipo.HeaderText = "Nombre del Equipo";
            this.nombreequipo.Name = "nombreequipo";
            this.nombreequipo.ReadOnly = true;
            // 
            // marca1
            // 
            this.marca1.HeaderText = "Marca";
            this.marca1.Name = "marca1";
            this.marca1.ReadOnly = true;
            // 
            // modelo1
            // 
            this.modelo1.HeaderText = "Modelo";
            this.modelo1.Name = "modelo1";
            this.modelo1.ReadOnly = true;
            // 
            // usuario1
            // 
            this.usuario1.HeaderText = "Usuario";
            this.usuario1.Name = "usuario1";
            this.usuario1.ReadOnly = true;
            // 
            // mtto
            // 
            this.mtto.HeaderText = "Mantenimiento";
            this.mtto.Name = "mtto";
            this.mtto.ReadOnly = true;
            // 
            // tipo1
            // 
            this.tipo1.HeaderText = "Tipo";
            this.tipo1.Name = "tipo1";
            this.tipo1.ReadOnly = true;
            // 
            // ram1
            // 
            this.ram1.HeaderText = "RAM";
            this.ram1.Name = "ram1";
            this.ram1.ReadOnly = true;
            // 
            // ddtotal1
            // 
            this.ddtotal1.HeaderText = "Espacio";
            this.ddtotal1.Name = "ddtotal1";
            this.ddtotal1.ReadOnly = true;
            // 
            // ddlibre1
            // 
            this.ddlibre1.HeaderText = "Espacio Libre";
            this.ddlibre1.Name = "ddlibre1";
            this.ddlibre1.ReadOnly = true;
            // 
            // so1
            // 
            this.so1.HeaderText = "Sistema Operativo";
            this.so1.Name = "so1";
            this.so1.ReadOnly = true;
            // 
            // licenciaso1
            // 
            this.licenciaso1.HeaderText = "Licencia SO";
            this.licenciaso1.Name = "licenciaso1";
            this.licenciaso1.ReadOnly = true;
            // 
            // procesador1
            // 
            this.procesador1.HeaderText = "Procesador";
            this.procesador1.Name = "procesador1";
            this.procesador1.ReadOnly = true;
            // 
            // arquitectura1
            // 
            this.arquitectura1.HeaderText = "Arquitectura";
            this.arquitectura1.Name = "arquitectura1";
            this.arquitectura1.ReadOnly = true;
            // 
            // numeroserie1
            // 
            this.numeroserie1.HeaderText = "Numero de Serie";
            this.numeroserie1.Name = "numeroserie1";
            this.numeroserie1.ReadOnly = true;
            // 
            // empresa1
            // 
            this.empresa1.HeaderText = "Empresa";
            this.empresa1.Name = "empresa1";
            this.empresa1.ReadOnly = true;
            // 
            // base1
            // 
            this.base1.HeaderText = "Base";
            this.base1.Name = "base1";
            this.base1.ReadOnly = true;
            // 
            // departamento1
            // 
            this.departamento1.HeaderText = "Departamento";
            this.departamento1.Name = "departamento1";
            this.departamento1.ReadOnly = true;
            // 
            // nombre1
            // 
            this.nombre1.HeaderText = "Nombre";
            this.nombre1.Name = "nombre1";
            this.nombre1.ReadOnly = true;
            // 
            // fechainicio1
            // 
            this.fechainicio1.HeaderText = "Fecha de Inicio";
            this.fechainicio1.Name = "fechainicio1";
            this.fechainicio1.ReadOnly = true;
            // 
            // horainicio1
            // 
            this.horainicio1.HeaderText = "Hora de Inicio";
            this.horainicio1.Name = "horainicio1";
            this.horainicio1.ReadOnly = true;
            // 
            // fechatermino1
            // 
            this.fechatermino1.HeaderText = "Fecha de Termino";
            this.fechatermino1.Name = "fechatermino1";
            this.fechatermino1.ReadOnly = true;
            // 
            // horatermino
            // 
            this.horatermino.HeaderText = "Hora de Termino";
            this.horatermino.Name = "horatermino";
            this.horatermino.ReadOnly = true;
            // 
            // observaciones1
            // 
            this.observaciones1.HeaderText = "Observaciones";
            this.observaciones1.Name = "observaciones1";
            this.observaciones1.ReadOnly = true;
            // 
            // macaddress
            // 
            this.macaddress.HeaderText = "MacAddress";
            this.macaddress.Name = "macaddress";
            this.macaddress.ReadOnly = true;
            this.macaddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.macaddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.macaddress.Text = "Ver Macs Address";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 543);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1088, 23);
            this.progressBar1.TabIndex = 78;
            // 
            // bwexcel
            // 
            this.bwexcel.WorkerReportsProgress = true;
            this.bwexcel.WorkerSupportsCancellation = true;
            this.bwexcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bwexcel_DoWork);
            this.bwexcel.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Bwexcel_ProgressChanged);
            this.bwexcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Bwexcel_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::InfEq.Properties.Resources.DisgustingSpiffyIguana_small;
            this.pictureBox1.Location = new System.Drawing.Point(399, 163);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 283);
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // reset
            // 
            this.reset.Image = global::InfEq.Properties.Resources.reset4;
            this.reset.Location = new System.Drawing.Point(1098, 154);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(91, 79);
            this.reset.TabIndex = 16;
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // regresar
            // 
            this.regresar.Image = global::InfEq.Properties.Resources.back1;
            this.regresar.Location = new System.Drawing.Point(1097, 442);
            this.regresar.Name = "regresar";
            this.regresar.Size = new System.Drawing.Size(91, 79);
            this.regresar.TabIndex = 18;
            this.regresar.UseVisualStyleBackColor = true;
            this.regresar.Click += new System.EventHandler(this.Regresar_Click);
            // 
            // exportarexcel
            // 
            this.exportarexcel.Image = global::InfEq.Properties.Resources.excel2;
            this.exportarexcel.Location = new System.Drawing.Point(1098, 292);
            this.exportarexcel.Name = "exportarexcel";
            this.exportarexcel.Size = new System.Drawing.Size(91, 79);
            this.exportarexcel.TabIndex = 17;
            this.exportarexcel.UseVisualStyleBackColor = true;
            this.exportarexcel.Click += new System.EventHandler(this.Exportarexcel_Click);
            // 
            // buscardetalle
            // 
            this.buscardetalle.Image = global::InfEq.Properties.Resources.search2;
            this.buscardetalle.Location = new System.Drawing.Point(1097, 12);
            this.buscardetalle.Name = "buscardetalle";
            this.buscardetalle.Size = new System.Drawing.Size(91, 79);
            this.buscardetalle.TabIndex = 15;
            this.buscardetalle.UseVisualStyleBackColor = true;
            this.buscardetalle.Click += new System.EventHandler(this.Buscardetalle_Click);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(2, 490);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1089, 34);
            this.label12.TabIndex = 80;
            this.label12.Text = "label12";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mac
            // 
            this.mac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mac.Location = new System.Drawing.Point(880, 106);
            this.mac.Name = "mac";
            this.mac.Size = new System.Drawing.Size(210, 22);
            this.mac.TabIndex = 81;
            this.mac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mac_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(876, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 20);
            this.label15.TabIndex = 82;
            this.label15.Text = "MacAddress";
            // 
            // mtto2
            // 
            this.mtto2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mtto2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtto2.FormattingEnabled = true;
            this.mtto2.Items.AddRange(new object[] {
            "NINGUNO",
            "CORRECTIVO",
            "PREVENTIVO",
            "EQUIPO NUEVO",
            "CAMBIO DE EQUIPO"});
            this.mtto2.Location = new System.Drawing.Point(712, 106);
            this.mtto2.Name = "mtto2";
            this.mtto2.Size = new System.Drawing.Size(162, 24);
            this.mtto2.TabIndex = 83;
            // 
            // mttolabel
            // 
            this.mttolabel.AutoSize = true;
            this.mttolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mttolabel.Location = new System.Drawing.Point(712, 86);
            this.mttolabel.Name = "mttolabel";
            this.mttolabel.Size = new System.Drawing.Size(114, 20);
            this.mttolabel.TabIndex = 84;
            this.mttolabel.Text = "Mantenimiento";
            // 
            // Buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 566);
            this.Controls.Add(this.mtto2);
            this.Controls.Add(this.mttolabel);
            this.Controls.Add(this.mac);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.equipos);
            this.Controls.Add(this.activo);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.regresar);
            this.Controls.Add(this.exportarexcel);
            this.Controls.Add(this.buscardetalle);
            this.Controls.Add(this.year);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.empresa);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.localidad);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.depa);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.marca);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.serialnumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.procesador);
            this.Controls.Add(this.so);
            this.Controls.Add(this.namemachine);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Buscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Equipo";
            this.Load += new System.EventHandler(this.Buscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.equipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox empresa;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox localidad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox depa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox marca;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox modelo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox serialnumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox procesador;
        private System.Windows.Forms.TextBox so;
        private System.Windows.Forms.TextBox namemachine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tipo;
        private System.Windows.Forms.ComboBox mes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox year;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buscardetalle;
        private System.Windows.Forms.Button exportarexcel;
        private System.Windows.Forms.Button regresar;
        private System.Windows.Forms.ToolTip toolregresar;
        private System.Windows.Forms.ToolTip toolexportar;
        private System.Windows.Forms.ToolTip tooldetalle;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.ToolTip toolreset;
        private System.Windows.Forms.TextBox activo;
        private System.Windows.Forms.DataGridView equipos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bwexcel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox mac;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn ids;
        private System.Windows.Forms.DataGridViewTextBoxColumn noactivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreequipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca1;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ram1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ddtotal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ddlibre1;
        private System.Windows.Forms.DataGridViewTextBoxColumn so1;
        private System.Windows.Forms.DataGridViewTextBoxColumn licenciaso1;
        private System.Windows.Forms.DataGridViewTextBoxColumn procesador1;
        private System.Windows.Forms.DataGridViewTextBoxColumn arquitectura1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroserie1;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresa1;
        private System.Windows.Forms.DataGridViewTextBoxColumn base1;
        private System.Windows.Forms.DataGridViewTextBoxColumn departamento1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechainicio1;
        private System.Windows.Forms.DataGridViewTextBoxColumn horainicio1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechatermino1;
        private System.Windows.Forms.DataGridViewTextBoxColumn horatermino;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones1;
        private System.Windows.Forms.DataGridViewButtonColumn macaddress;
        private System.Windows.Forms.ComboBox mtto2;
        private System.Windows.Forms.Label mttolabel;
    }
}