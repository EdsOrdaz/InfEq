namespace InfEq
{
    partial class ReportInfEq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportInfEq));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.Instalar_programa = new System.ComponentModel.BackgroundWorker();
            this.detener_programa = new System.ComponentModel.BackgroundWorker();
            this.button4 = new System.Windows.Forms.Button();
            this.reporte = new System.Windows.Forms.Button();
            this.detener = new System.Windows.Forms.Button();
            this.instalar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Instalar_programa
            // 
            this.Instalar_programa.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Instalar_programa_DoWork);
            this.Instalar_programa.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Instalar_programa_RunWorkerCompleted);
            // 
            // detener_programa
            // 
            this.detener_programa.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Detener_programa_DoWork);
            this.detener_programa.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Detener_programa_RunWorkerCompleted);
            // 
            // button4
            // 
            this.button4.Image = global::InfEq.Properties.Resources.back1;
            this.button4.Location = new System.Drawing.Point(119, 108);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 79);
            this.button4.TabIndex = 4;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // reporte
            // 
            this.reporte.Image = global::InfEq.Properties.Resources.graficas_reportes;
            this.reporte.Location = new System.Drawing.Point(12, 108);
            this.reporte.Name = "reporte";
            this.reporte.Size = new System.Drawing.Size(91, 79);
            this.reporte.TabIndex = 3;
            this.reporte.UseVisualStyleBackColor = true;
            this.reporte.Click += new System.EventHandler(this.Reporte_Click);
            // 
            // detener
            // 
            this.detener.Image = global::InfEq.Properties.Resources.detener;
            this.detener.Location = new System.Drawing.Point(119, 12);
            this.detener.Name = "detener";
            this.detener.Size = new System.Drawing.Size(91, 79);
            this.detener.TabIndex = 2;
            this.detener.UseVisualStyleBackColor = true;
            this.detener.Click += new System.EventHandler(this.Detener_Click);
            // 
            // instalar
            // 
            this.instalar.Image = global::InfEq.Properties.Resources.instalar;
            this.instalar.Location = new System.Drawing.Point(12, 12);
            this.instalar.Name = "instalar";
            this.instalar.Size = new System.Drawing.Size(91, 79);
            this.instalar.TabIndex = 1;
            this.instalar.UseVisualStyleBackColor = true;
            this.instalar.Click += new System.EventHandler(this.Instalar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::InfEq.Properties.Resources.load_balls;
            this.pictureBox1.Location = new System.Drawing.Point(12, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 198);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // ReportInfEq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 199);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.reporte);
            this.Controls.Add(this.detener);
            this.Controls.Add(this.instalar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportInfEq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportInfEq";
            this.Load += new System.EventHandler(this.ReportInfEq_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button instalar;
        private System.Windows.Forms.Button detener;
        private System.Windows.Forms.Button reporte;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.ComponentModel.BackgroundWorker Instalar_programa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker detener_programa;
    }
}