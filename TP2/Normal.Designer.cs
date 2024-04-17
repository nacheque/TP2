namespace TP2
{
    partial class Normal
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
            grdNormal = new DataGridView();
            Nro = new DataGridViewTextBoxColumn();
            RND = new DataGridViewTextBoxColumn();
            label1 = new Label();
            cmbIntervalos = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)grdNormal).BeginInit();
            SuspendLayout();
            // 
            // grdNormal
            // 
            grdNormal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdNormal.Columns.AddRange(new DataGridViewColumn[] { Nro, RND });
            grdNormal.Location = new Point(12, 12);
            grdNormal.Name = "grdNormal";
            grdNormal.Size = new Size(241, 345);
            grdNormal.TabIndex = 0;
            // 
            // Nro
            // 
            Nro.HeaderText = "Posicion";
            Nro.Name = "Nro";
            Nro.ReadOnly = true;
            // 
            // RND
            // 
            RND.HeaderText = "RND";
            RND.Name = "RND";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(12, 360);
            label1.Name = "label1";
            label1.Size = new Size(226, 28);
            label1.TabIndex = 4;
            label1.Text = "Cantidad de Intervalos";
            // 
            // cmbIntervalos
            // 
            cmbIntervalos.FormattingEnabled = true;
            cmbIntervalos.Location = new Point(12, 401);
            cmbIntervalos.Name = "cmbIntervalos";
            cmbIntervalos.Size = new Size(121, 23);
            cmbIntervalos.TabIndex = 5;
            // 
            // Normal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbIntervalos);
            Controls.Add(label1);
            Controls.Add(grdNormal);
            Name = "Normal";
            Text = "Normal";
            Load += Normal_Load;
            ((System.ComponentModel.ISupportInitialize)grdNormal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdNormal;
        private DataGridViewTextBoxColumn Nro;
        private DataGridViewTextBoxColumn RND;
        private Label label1;
        private ComboBox cmbIntervalos;
    }
}