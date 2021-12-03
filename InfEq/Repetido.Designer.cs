namespace InfEq
{
    partial class Repetido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Repetido));
            this.equipos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreequipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.guardar = new System.Windows.Forms.Button();
            this.regresar = new System.Windows.Forms.Button();
            this.exportar = new System.Windows.Forms.Button();
            this.toolguardar = new System.Windows.Forms.ToolTip(this.components);
            this.toolexportar = new System.Windows.Forms.ToolTip(this.components);
            this.toolregresar = new System.Windows.Forms.ToolTip(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.equipos)).BeginInit();
            this.SuspendLayout();
            // 
            // equipos
            // 
            this.equipos.AllowUserToAddRows = false;
            this.equipos.AllowUserToDeleteRows = false;
            this.equipos.AllowUserToOrderColumns = true;
            this.equipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombreequipo,
            this.marca1,
            this.modelo1,
            this.usuario1,
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
            this.observaciones1});
            this.equipos.EnableHeadersVisualStyles = false;
            this.equipos.Location = new System.Drawing.Point(0, 0);
            this.equipos.Name = "equipos";
            this.equipos.ReadOnly = true;
            this.equipos.Size = new System.Drawing.Size(901, 336);
            this.equipos.TabIndex = 74;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
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
            // guardar
            // 
            this.guardar.Image = global::InfEq.Properties.Resources.save2;
            this.guardar.Location = new System.Drawing.Point(907, 25);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(91, 79);
            this.guardar.TabIndex = 1;
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // regresar
            // 
            this.regresar.Image = global::InfEq.Properties.Resources.back1;
            this.regresar.Location = new System.Drawing.Point(907, 246);
            this.regresar.Name = "regresar";
            this.regresar.Size = new System.Drawing.Size(91, 79);
            this.regresar.TabIndex = 3;
            this.regresar.UseVisualStyleBackColor = true;
            this.regresar.Click += new System.EventHandler(this.Regresar_Click);
            // 
            // exportar
            // 
            this.exportar.Image = global::InfEq.Properties.Resources.excel2;
            this.exportar.Location = new System.Drawing.Point(907, 134);
            this.exportar.Name = "exportar";
            this.exportar.Size = new System.Drawing.Size(91, 79);
            this.exportar.TabIndex = 2;
            this.exportar.UseVisualStyleBackColor = true;
            this.exportar.Click += new System.EventHandler(this.Exportar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 120);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(874, 69);
            this.progressBar1.TabIndex = 75;
            // 
            // Repetido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 348);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.exportar);
            this.Controls.Add(this.regresar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.equipos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Repetido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equipo detectado";
            this.Load += new System.EventHandler(this.Repetido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.equipos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView equipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreequipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca1;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario1;
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
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button regresar;
        private System.Windows.Forms.Button exportar;
        private System.Windows.Forms.ToolTip toolguardar;
        private System.Windows.Forms.ToolTip toolexportar;
        private System.Windows.Forms.ToolTip toolregresar;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}