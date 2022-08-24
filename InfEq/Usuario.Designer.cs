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
            this.delete = new System.Windows.Forms.Button();
            this.cerrarsesion = new System.Windows.Forms.Button();
            this.agregarusuario = new System.Windows.Forms.Button();
            this.listausuario = new System.Windows.Forms.Button();
            this.config_correo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // delete
            // 
            this.delete.Image = global::InfEq.Properties.Resources.delete;
            this.delete.Location = new System.Drawing.Point(12, 95);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(91, 79);
            this.delete.TabIndex = 5;
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // cerrarsesion
            // 
            this.cerrarsesion.Image = global::InfEq.Properties.Resources.loggoff;
            this.cerrarsesion.Location = new System.Drawing.Point(230, 95);
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
            // config_correo
            // 
            this.config_correo.Image = global::InfEq.Properties.Resources.configurarcorreos;
            this.config_correo.Location = new System.Drawing.Point(230, 12);
            this.config_correo.Name = "config_correo";
            this.config_correo.Size = new System.Drawing.Size(91, 79);
            this.config_correo.TabIndex = 8;
            this.config_correo.UseVisualStyleBackColor = true;
            this.config_correo.Click += new System.EventHandler(this.config_correo_Click);
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 185);
            this.Controls.Add(this.config_correo);
            this.Controls.Add(this.delete);
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
        private System.Windows.Forms.ToolTip tooltipsubirxml;
        private System.Windows.Forms.ToolTip tooltipreporte;
        private System.Windows.Forms.ToolTip toolTipsirac;
        private System.Windows.Forms.ToolTip toolTipreportes;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button config_correo;
    }
}