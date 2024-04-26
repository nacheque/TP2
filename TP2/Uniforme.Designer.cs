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
            label2 = new Label();
            btnCC = new Button();
            txtCC = new TextBox();
            btnKS = new Button();
            txtKS = new TextBox();
            txtV = new TextBox();
            label3 = new Label();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.Location = new Point(19, 457);
            label2.Name = "label2";
            label2.Size = new Size(194, 28);
            label2.TabIndex = 4;
            label2.Text = "Pruebas de Bondad";
            // 
            // btnCC
            // 
            btnCC.Location = new Point(12, 488);
            btnCC.Name = "btnCC";
            btnCC.Size = new Size(97, 40);
            btnCC.TabIndex = 5;
            btnCC.Text = "Calcular Chi Cuadrado";
            btnCC.UseVisualStyleBackColor = true;
            btnCC.Click += btnCC_Click;
            // 
            // txtCC
            // 
            txtCC.Location = new Point(115, 498);
            txtCC.Name = "txtCC";
            txtCC.Size = new Size(100, 23);
            txtCC.TabIndex = 6;
            // 
            // btnKS
            // 
            btnKS.Location = new Point(12, 534);
            btnKS.Name = "btnKS";
            btnKS.Size = new Size(97, 40);
            btnKS.TabIndex = 7;
            btnKS.Text = "Calcular KS";
            btnKS.UseVisualStyleBackColor = true;
            btnKS.Click += btnKS_Click;
            // 
            // txtKS
            // 
            txtKS.Location = new Point(115, 540);
            txtKS.Name = "txtKS";
            txtKS.Size = new Size(100, 23);
            txtKS.TabIndex = 8;
            // 
            // txtV
            // 
            txtV.Location = new Point(262, 498);
            txtV.Name = "txtV";
            txtV.Size = new Size(27, 23);
            txtV.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(232, 501);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 10;
            label3.Text = "v =";
            // 
            // Uniforme
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 575);
            Controls.Add(label3);
            Controls.Add(txtV);
            Controls.Add(txtKS);
            Controls.Add(btnKS);
            Controls.Add(txtCC);
            Controls.Add(btnCC);
            Controls.Add(label2);
            Controls.Add(btnGenerarHistograma);
            Controls.Add(label1);
            Controls.Add(cmbIntervalos);
            Controls.Add(grdUniforme);
            Name = "Uniforme";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Label label2;
        private Button btnCC;
        private TextBox txtCC;
        private Button btnKS;
        private TextBox txtKS;
        private TextBox txtV;
        private Label label3;
    }
}