namespace TP2
{
    partial class Uniforme
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
            grdUniforme = new DataGridView();
            Posicion = new DataGridViewTextBoxColumn();
            RND = new DataGridViewTextBoxColumn();
            cmbIntervalos = new ComboBox();
            label1 = new Label();
            btnGenerarHistograma = new Button();
            ((System.ComponentModel.ISupportInitialize)grdUniforme).BeginInit();
            SuspendLayout();
            // 
            // grdUniforme
            // 
            grdUniforme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdUniforme.Columns.AddRange(new DataGridViewColumn[] { Posicion, RND });
            grdUniforme.Location = new Point(12, 12);
            grdUniforme.Name = "grdUniforme";
            grdUniforme.Size = new Size(244, 373);
            grdUniforme.TabIndex = 0;
            // 
            // Posicion
            // 
            Posicion.HeaderText = "Nro";
            Posicion.Name = "Posicion";
            Posicion.ReadOnly = true;
            // 
            // RND
            // 
            RND.HeaderText = "RND";
            RND.Name = "RND";
            // 
            // cmbIntervalos
            // 
            cmbIntervalos.FormattingEnabled = true;
            cmbIntervalos.Location = new Point(12, 419);
            cmbIntervalos.Name = "cmbIntervalos";
            cmbIntervalos.Size = new Size(121, 23);
            cmbIntervalos.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(12, 388);
            label1.Name = "label1";
            label1.Size = new Size(226, 28);
            label1.TabIndex = 2;
            label1.Text = "Cantidad de Intervalos";
            // 
            // btnGenerarHistograma
            // 
            btnGenerarHistograma.Location = new Point(139, 418);
            btnGenerarHistograma.Name = "btnGenerarHistograma";
            btnGenerarHistograma.Size = new Size(143, 26);
            btnGenerarHistograma.TabIndex = 3;
            btnGenerarHistograma.Text = "Generar Histograma";
            btnGenerarHistograma.UseVisualStyleBackColor = true;
            btnGenerarHistograma.Click += btnGenerarHistograma_Click;
            // 
            // Uniforme
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 456);
            Controls.Add(btnGenerarHistograma);
            Controls.Add(label1);
            Controls.Add(cmbIntervalos);
            Controls.Add(grdUniforme);
            Name = "Uniforme";
            Text = "Distribucion Uniforme[A,B]";
            Load += Uniforme_Load;
            ((System.ComponentModel.ISupportInitialize)grdUniforme).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdUniforme;
        private ComboBox cmbIntervalos;
        private Label label1;
        private DataGridViewTextBoxColumn Posicion;
        private DataGridViewTextBoxColumn RND;
        private Button btnGenerarHistograma;
    }
}