namespace InfEq
{
    partial class MacAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacAddress));
            this.macstabla = new System.Windows.Forms.DataGridView();
            this.interfase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.copiar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.macstabla)).BeginInit();
            this.SuspendLayout();
            // 
            // macstabla
            // 
            this.macstabla.AllowUserToAddRows = false;
            this.macstabla.AllowUserToDeleteRows = false;
            this.macstabla.AllowUserToOrderColumns = true;
            this.macstabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.macstabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.interfase,
            this.mac,
            this.copiar});
            this.macstabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.macstabla.EnableHeadersVisualStyles = false;
            this.macstabla.Location = new System.Drawing.Point(0, 0);
            this.macstabla.Name = "macstabla";
            this.macstabla.ReadOnly = true;
            this.macstabla.Size = new System.Drawing.Size(548, 231);
            this.macstabla.TabIndex = 0;
            this.macstabla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Macstabla_CellContentClick);
            // 
            // interfase
            // 
            this.interfase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.interfase.HeaderText = "Interfase";
            this.interfase.Name = "interfase";
            this.interfase.ReadOnly = true;
            // 
            // mac
            // 
            this.mac.HeaderText = "Mac Address";
            this.mac.Name = "mac";
            this.mac.ReadOnly = true;
            this.mac.Width = 150;
            // 
            // copiar
            // 
            this.copiar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.copiar.HeaderText = "Copiar Mac";
            this.copiar.Name = "copiar";
            this.copiar.ReadOnly = true;
            this.copiar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.copiar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.copiar.Width = 86;
            // 
            // MacAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 231);
            this.Controls.Add(this.macstabla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MacAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver MacAddress";
            this.Deactivate += new System.EventHandler(this.MacAddress_Deactivate);
            this.Load += new System.EventHandler(this.MacAddress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.macstabla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView macstabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn interfase;
        private System.Windows.Forms.DataGridViewTextBoxColumn mac;
        private System.Windows.Forms.DataGridViewButtonColumn copiar;
    }
}