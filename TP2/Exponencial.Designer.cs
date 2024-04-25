namespace TP2
{
    partial class Exponencial
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
            grdExponencial = new DataGridView();
            Nro = new DataGridViewTextBoxColumn();
            RND = new DataGridViewTextBoxColumn();
            label1 = new Label();
            cmbIntervalos = new ComboBox();
            btnGenerarHistograma = new Button();
            btnCC = new Button();
            label2 = new Label();
            btnKS = new Button();
            txtCC = new TextBox();
            txtKS = new TextBox();
            ((System.ComponentModel.ISupportInitialize)grdExponencial).BeginInit();
            SuspendLayout();
            // 
            // grdExponencial
            // 
            grdExponencial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdExponencial.Columns.AddRange(new DataGridViewColumn[] { Nro, RND });
            grdExponencial.Location = new Point(12, 12);
            grdExponencial.Name = "grdExponencial";
            grdExponencial.Size = new Size(240, 358);
            grdExponencial.TabIndex = 0;
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
            label1.Location = new Point(12, 373);
            label1.Name = "label1";
            label1.Size = new Size(226, 28);
            label1.TabIndex = 3;
            label1.Text = "Cantidad de Intervalos";
            // 
            // cmbIntervalos
            // 
            cmbIntervalos.FormattingEnabled = true;
            cmbIntervalos.Location = new Point(12, 404);
            cmbIntervalos.Name = "cmbIntervalos";
            cmbIntervalos.Size = new Size(121, 23);
            cmbIntervalos.TabIndex = 4;
            // 
            // btnGenerarHistograma
            // 
            btnGenerarHistograma.Location = new Point(139, 404);
            btnGenerarHistograma.Name = "btnGenerarHistograma";
            btnGenerarHistograma.Size = new Size(143, 26);
            btnGenerarHistograma.TabIndex = 5;
            btnGenerarHistograma.Text = "Generar Histograma";
            btnGenerarHistograma.UseVisualStyleBackColor = true;
            btnGenerarHistograma.Click += btnGenerarHistograma_Click;
            // 
            // btnCC
            // 
            btnCC.Location = new Point(12, 461);
            btnCC.Name = "btnCC";
            btnCC.Size = new Size(97, 40);
            btnCC.TabIndex = 6;
            btnCC.Text = "Calcular Chi Cuadrado";
            btnCC.UseVisualStyleBackColor = true;
            btnCC.Click += btnCC_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.Location = new Point(12, 430);
            label2.Name = "label2";
            label2.Size = new Size(194, 28);
            label2.TabIndex = 7;
            label2.Text = "Pruebas de Bondad";
            // 
            // btnKS
            // 
            btnKS.Location = new Point(12, 507);
            btnKS.Name = "btnKS";
            btnKS.Size = new Size(97, 40);
            btnKS.TabIndex = 8;
            btnKS.Text = "Calcular KS";
            btnKS.UseVisualStyleBackColor = true;
            btnKS.Click += btnKS_Click;
            // 
            // txtCC
            // 
            txtCC.Location = new Point(115, 471);
            txtCC.Name = "txtCC";
            txtCC.Size = new Size(100, 23);
            txtCC.TabIndex = 9;
            // 
            // txtKS
            // 
            txtKS.Location = new Point(115, 517);
            txtKS.Name = "txtKS";
            txtKS.Size = new Size(100, 23);
            txtKS.TabIndex = 10;
            // 
            // Exponencial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 558);
            Controls.Add(txtKS);
            Controls.Add(txtCC);
            Controls.Add(btnKS);
            Controls.Add(label2);
            Controls.Add(btnCC);
            Controls.Add(btnGenerarHistograma);
            Controls.Add(cmbIntervalos);
            Controls.Add(label1);
            Controls.Add(grdExponencial);
            Name = "Exponencial";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Exponencial Negativa[me]";
            Load += Poisson_Load;
            ((System.ComponentModel.ISupportInitialize)grdExponencial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdExponencial;
        private DataGridViewTextBoxColumn Nro;
        private DataGridViewTextBoxColumn RND;
        private Label label1;
        private ComboBox cmbIntervalos;
        private Button btnGenerarHistograma;
        private Button btnCC;
        private Label label2;
        private Button btnKS;
        private TextBox txtCC;
        private TextBox txtKS;
    }
}