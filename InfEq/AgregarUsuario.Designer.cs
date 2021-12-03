namespace InfEq
{
    partial class AgregarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarUsuario));
            this.estatus = new System.Windows.Forms.ComboBox();
            this.privilegios = new System.Windows.Forms.ComboBox();
            this.password = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.usuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.regresar = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // estatus
            // 
            this.estatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estatus.FormattingEnabled = true;
            this.estatus.Items.AddRange(new object[] {
            "Activo",
            "Desactivado"});
            this.estatus.Location = new System.Drawing.Point(81, 173);
            this.estatus.Name = "estatus";
            this.estatus.Size = new System.Drawing.Size(221, 24);
            this.estatus.TabIndex = 5;
            // 
            // privilegios
            // 
            this.privilegios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.privilegios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.privilegios.FormattingEnabled = true;
            this.privilegios.Items.AddRange(new object[] {
            "Administrador",
            "Usuario"});
            this.privilegios.Location = new System.Drawing.Point(100, 133);
            this.privilegios.Name = "privilegios";
            this.privilegios.Size = new System.Drawing.Size(202, 24);
            this.privilegios.TabIndex = 4;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(101, 91);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(201, 22);
            this.password.TabIndex = 3;
            this.password.UseSystemPasswordChar = true;
            // 
            // nombre
            // 
            this.nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre.Location = new System.Drawing.Point(81, 48);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(221, 22);
            this.nombre.TabIndex = 2;
            // 
            // usuario
            // 
            this.usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario.Location = new System.Drawing.Point(81, 12);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(221, 22);
            this.usuario.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Estatus:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Privilegios:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Contraseña: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Nombre: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Usuario: ";
            // 
            // regresar
            // 
            this.regresar.Image = global::InfEq.Properties.Resources.back1;
            this.regresar.Location = new System.Drawing.Point(313, 114);
            this.regresar.Name = "regresar";
            this.regresar.Size = new System.Drawing.Size(91, 79);
            this.regresar.TabIndex = 7;
            this.regresar.UseVisualStyleBackColor = true;
            this.regresar.Click += new System.EventHandler(this.Regresar_Click);
            // 
            // guardar
            // 
            this.guardar.Image = global::InfEq.Properties.Resources.save2;
            this.guardar.Location = new System.Drawing.Point(313, 12);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(91, 79);
            this.guardar.TabIndex = 6;
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // AgregarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 212);
            this.Controls.Add(this.regresar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.estatus);
            this.Controls.Add(this.privilegios);
            this.Controls.Add(this.password);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Usuario";
            this.Load += new System.EventHandler(this.AgregarUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button regresar;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.ComboBox estatus;
        private System.Windows.Forms.ComboBox privilegios;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}