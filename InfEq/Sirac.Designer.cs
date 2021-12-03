namespace InfEq
{
    partial class Sirac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sirac));
            this.empres1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pedcompra = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nomusuario = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.marca = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.modelo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.serialnumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numerodeactivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.equipos = new System.Windows.Forms.DataGridView();
            this.numeroeconomico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroserie1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centrodecostos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaasignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedidocompra1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ubicacion1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.regresar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.equipos)).BeginInit();
            this.SuspendLayout();
            // 
            // empres1
            // 
            this.empres1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.empres1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empres1.Location = new System.Drawing.Point(739, 76);
            this.empres1.Name = "empres1";
            this.empres1.Size = new System.Drawing.Size(217, 22);
            this.empres1.TabIndex = 7;
            this.empres1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Empres1_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(735, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 94;
            this.label14.Text = "Empresa";
            // 
            // pedcompra
            // 
            this.pedcompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.pedcompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pedcompra.Location = new System.Drawing.Point(496, 76);
            this.pedcompra.Name = "pedcompra";
            this.pedcompra.Size = new System.Drawing.Size(217, 22);
            this.pedcompra.TabIndex = 6;
            this.pedcompra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pedcompra_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(492, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 20);
            this.label13.TabIndex = 93;
            this.label13.Text = "Pedido de Compra";
            // 
            // nomusuario
            // 
            this.nomusuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomusuario.Location = new System.Drawing.Point(7, 76);
            this.nomusuario.Name = "nomusuario";
            this.nomusuario.Size = new System.Drawing.Size(217, 22);
            this.nomusuario.TabIndex = 5;
            this.nomusuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nomusuario_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 92;
            this.label11.Text = "Usuario";
            // 
            // marca
            // 
            this.marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marca.Location = new System.Drawing.Point(250, 28);
            this.marca.Name = "marca";
            this.marca.Size = new System.Drawing.Size(217, 22);
            this.marca.TabIndex = 2;
            this.marca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Marca_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(246, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 20);
            this.label10.TabIndex = 91;
            this.label10.Text = "Marca";
            // 
            // modelo
            // 
            this.modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelo.Location = new System.Drawing.Point(496, 28);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(217, 22);
            this.modelo.TabIndex = 3;
            this.modelo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Modelo_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(492, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 90;
            this.label9.Text = "Modelo";
            // 
            // serialnumber
            // 
            this.serialnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialnumber.Location = new System.Drawing.Point(739, 28);
            this.serialnumber.Name = "serialnumber";
            this.serialnumber.Size = new System.Drawing.Size(217, 22);
            this.serialnumber.TabIndex = 4;
            this.serialnumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Serialnumber_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(735, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 20);
            this.label8.TabIndex = 89;
            this.label8.Text = "Numero de Serie";
            // 
            // numerodeactivo
            // 
            this.numerodeactivo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.numerodeactivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numerodeactivo.Location = new System.Drawing.Point(7, 28);
            this.numerodeactivo.Name = "numerodeactivo";
            this.numerodeactivo.Size = new System.Drawing.Size(217, 22);
            this.numerodeactivo.TabIndex = 1;
            this.numerodeactivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Numerodeactivo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 85;
            this.label4.Text = "Numero de Activo";
            // 
            // equipos
            // 
            this.equipos.AllowUserToAddRows = false;
            this.equipos.AllowUserToDeleteRows = false;
            this.equipos.AllowUserToOrderColumns = true;
            this.equipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroeconomico,
            this.equipo1,
            this.marca1,
            this.modelo1,
            this.numeroserie1,
            this.usuario1,
            this.ubicacion,
            this.empresa,
            this.centrodecostos,
            this.fechaasignacion,
            this.pedidocompra1,
            this.obs});
            this.equipos.EnableHeadersVisualStyles = false;
            this.equipos.Location = new System.Drawing.Point(7, 104);
            this.equipos.Name = "equipos";
            this.equipos.ReadOnly = true;
            this.equipos.Size = new System.Drawing.Size(1150, 346);
            this.equipos.TabIndex = 95;
            // 
            // numeroeconomico
            // 
            this.numeroeconomico.HeaderText = "No. Activo";
            this.numeroeconomico.Name = "numeroeconomico";
            this.numeroeconomico.ReadOnly = true;
            // 
            // equipo1
            // 
            this.equipo1.HeaderText = "Equipo";
            this.equipo1.Name = "equipo1";
            this.equipo1.ReadOnly = true;
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
            // numeroserie1
            // 
            this.numeroserie1.HeaderText = "Numero de Serie";
            this.numeroserie1.Name = "numeroserie1";
            this.numeroserie1.ReadOnly = true;
            // 
            // usuario1
            // 
            this.usuario1.HeaderText = "Usuario";
            this.usuario1.Name = "usuario1";
            this.usuario1.ReadOnly = true;
            // 
            // ubicacion
            // 
            this.ubicacion.HeaderText = "Ubicacion";
            this.ubicacion.Name = "ubicacion";
            this.ubicacion.ReadOnly = true;
            // 
            // empresa
            // 
            this.empresa.HeaderText = "Empresa";
            this.empresa.Name = "empresa";
            this.empresa.ReadOnly = true;
            // 
            // centrodecostos
            // 
            this.centrodecostos.HeaderText = "Centro de Costos";
            this.centrodecostos.Name = "centrodecostos";
            this.centrodecostos.ReadOnly = true;
            // 
            // fechaasignacion
            // 
            this.fechaasignacion.HeaderText = "Fecha de Asignacion";
            this.fechaasignacion.Name = "fechaasignacion";
            this.fechaasignacion.ReadOnly = true;
            // 
            // pedidocompra1
            // 
            this.pedidocompra1.HeaderText = "Pedido de Compra";
            this.pedidocompra1.Name = "pedidocompra1";
            this.pedidocompra1.ReadOnly = true;
            // 
            // obs
            // 
            this.obs.HeaderText = "Observaciones";
            this.obs.Name = "obs";
            this.obs.ReadOnly = true;
            // 
            // ubicacion1
            // 
            this.ubicacion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ubicacion1.Location = new System.Drawing.Point(250, 76);
            this.ubicacion1.Name = "ubicacion1";
            this.ubicacion1.Size = new System.Drawing.Size(217, 22);
            this.ubicacion1.TabIndex = 97;
            this.ubicacion1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ubicacion1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(246, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 98;
            this.label1.Text = "Ubicación";
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
            this.progressBar1.Location = new System.Drawing.Point(7, 410);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1150, 21);
            this.progressBar1.TabIndex = 100;
            // 
            // regresar
            // 
            this.regresar.Image = global::InfEq.Properties.Resources.back1;
            this.regresar.Location = new System.Drawing.Point(1066, 23);
            this.regresar.Name = "regresar";
            this.regresar.Size = new System.Drawing.Size(91, 79);
            this.regresar.TabIndex = 96;
            this.regresar.UseVisualStyleBackColor = true;
            this.regresar.Click += new System.EventHandler(this.Regresar_Click);
            // 
            // buscar
            // 
            this.buscar.Image = global::InfEq.Properties.Resources.search2;
            this.buscar.Location = new System.Drawing.Point(962, 23);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(91, 79);
            this.buscar.TabIndex = 8;
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.Buscardetalle_Click);
            // 
            // Sirac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 453);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ubicacion1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.regresar);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.equipos);
            this.Controls.Add(this.empres1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pedcompra);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nomusuario);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.marca);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.serialnumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numerodeactivo);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Sirac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar en Sirac";
            this.Load += new System.EventHandler(this.Sirac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.equipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox empres1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox pedcompra;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox nomusuario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox marca;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox modelo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox serialnumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox numerodeactivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView equipos;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button regresar;
        private System.Windows.Forms.TextBox ubicacion1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroeconomico;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca1;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroserie1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn centrodecostos;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaasignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedidocompra1;
        private System.Windows.Forms.DataGridViewTextBoxColumn obs;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}