namespace InfEq
{
    partial class Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuario));
            this.toolTiplistausuario = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipagregarusuario = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipcerrarsesion = new System.Windows.Forms.ToolTip(this.components);
            this.toolTiprConfCorreo = new System.Windows.Forms.ToolTip(this.components);
            this.tooltipsubirxml = new System.Windows.Forms.ToolTip(this.components);
            this.tooltipreporte = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipsirac = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipreportes = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.config_correo = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.reportes = new System.Windows.Forms.Button();
            this.sirac = new System.Windows.Forms.Button();
            this.reportemensual = new System.Windows.Forms.Button();
            this.subirxml = new System.Windows.Forms.Button();
            this.cerrarsesion = new System.Windows.Forms.Button();
            this.agregarusuario = new System.Windows.Forms.Button();
            this.listausuario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // config_correo
            // 
            this.config_correo.Image = global::InfEq.Properties.Resources.configurarcorreos;
            this.config_correo.Location = new System.Drawing.Point(120, 180);
            this.config_correo.Name = "config_correo";
            this.config_correo.Size = new System.Drawing.Size(91, 79);
            this.config_correo.TabIndex = 8;
            this.config_correo.UseVisualStyleBackColor = true;
            this.config_correo.Click += new System.EventHandler(this.config_correo_Click);
            // 
            // delete
            // 
            this.delete.Image = global::InfEq.Properties.Resources.delete;
            this.delete.Location = new System.Drawing.Point(120, 95);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(91, 79);
            this.delete.TabIndex = 5;
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // reportes
            // 
            this.reportes.Image = ((System.Drawing.Image)(resources.GetObject("reportes.Image")));
            this.reportes.Location = new System.Drawing.Point(230, 95);
            this.reportes.Name = "reportes";
            this.reportes.Size = new System.Drawing.Size(91, 79);
            this.reportes.TabIndex = 6;
            this.reportes.UseVisualStyleBackColor = true;
            this.reportes.Click += new System.EventHandler(this.Button2_Click);
            // 
            // sirac
            // 
            this.sirac.Image = global::InfEq.Properties.Resources.SIRAC;
            this.sirac.Location = new System.Drawing.Point(12, 180);
            this.sirac.Name = "sirac";
            this.sirac.Size = new System.Drawing.Size(91, 79);
            this.sirac.TabIndex = 7;
            this.sirac.UseVisualStyleBackColor = true;
            this.sirac.Click += new System.EventHandler(this.Button1_Click);
            // 
            // reportemensual
            // 
            this.reportemensual.Image = global::InfEq.Properties.Resources.reporte;
            this.reportemensual.Location = new System.Drawing.Point(12, 95);
            this.reportemensual.Name = "reportemensual";
            this.reportemensual.Size = new System.Drawing.Size(91, 79);
            this.reportemensual.TabIndex = 4;
            this.reportemensual.UseVisualStyleBackColor = true;
            this.reportemensual.Click += new System.EventHandler(this.Reportemensual_Click);
            // 
            // subirxml
            // 
            this.subirxml.Image = global::InfEq.Properties.Resources.xmlupload;
            this.subirxml.Location = new System.Drawing.Point(230, 10);
            this.subirxml.Name = "subirxml";
            this.subirxml.Size = new System.Drawing.Size(91, 79);
            this.subirxml.TabIndex = 3;
            this.subirxml.UseVisualStyleBackColor = true;
            this.subirxml.Click += new System.EventHandler(this.Subirxml_Click);
            // 
            // cerrarsesion
            // 
            this.cerrarsesion.Image = global::InfEq.Properties.Resources.loggoff;
            this.cerrarsesion.Location = new System.Drawing.Point(230, 180);
            this.cerrarsesion.Name = "cerrarsesion";
            this.cerrarsesion.Size = new System.Drawing.Size(91, 79);
            this.cerrarsesion.TabIndex = 9;
            this.cerrarsesion.UseVisualStyleBackColor = true;
            this.cerrarsesion.Click += new System.EventHandler(this.Cerrarsesion_Click);
            // 
            // agregarusuario
            // 
            this.agregarusuario.Image = global::InfEq.Properties.Resources.adduser;
            this.agregarusuario.Location = new System.Drawing.Point(120, 10);
            this.agregarusuario.Name = "agregarusuario";
            this.agregarusuario.Size = new System.Drawing.Size(91, 79);
            this.agregarusuario.TabIndex = 2;
            this.agregarusuario.UseVisualStyleBackColor = true;
            this.agregarusuario.Click += new System.EventHandler(this.Agregarusuario_Click);
            // 
            // listausuario
            // 
            this.listausuario.Image = global::InfEq.Properties.Resources.listausers;
            this.listausuario.Location = new System.Drawing.Point(12, 10);
            this.listausuario.Name = "listausuario";
            this.listausuario.Size = new System.Drawing.Size(91, 79);
            this.listausuario.TabIndex = 1;
            this.listausuario.UseVisualStyleBackColor = true;
            this.listausuario.Click += new System.EventHandler(this.Listausuario_Click);
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 270);
            this.Controls.Add(this.config_correo);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.reportes);
            this.Controls.Add(this.sirac);
            this.Controls.Add(this.reportemensual);
            this.Controls.Add(this.subirxml);
            this.Controls.Add(this.cerrarsesion);
            this.Controls.Add(this.agregarusuario);
            this.Controls.Add(this.listausuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Administración";
            this.Load += new System.EventHandler(this.Usuario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button listausuario;
        private System.Windows.Forms.Button agregarusuario;
        private System.Windows.Forms.Button cerrarsesion;
        private System.Windows.Forms.ToolTip toolTiplistausuario;
        private System.Windows.Forms.ToolTip toolTipagregarusuario;
        private System.Windows.Forms.ToolTip toolTipcerrarsesion;
        private System.Windows.Forms.ToolTip toolTiprConfCorreo;
        private System.Windows.Forms.Button subirxml;
        private System.Windows.Forms.ToolTip tooltipsubirxml;
        private System.Windows.Forms.Button reportemensual;
        private System.Windows.Forms.ToolTip tooltipreporte;
        private System.Windows.Forms.Button sirac;
        private System.Windows.Forms.Button reportes;
        private System.Windows.Forms.ToolTip toolTipsirac;
        private System.Windows.Forms.ToolTip toolTipreportes;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button config_correo;
    }
}