﻿namespace TP2
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
            btnGenerarHistograma = new Button();
            label2 = new Label();
            btnCC = new Button();
            btnKS = new Button();
            txtCC = new TextBox();
            txtKS = new TextBox();
            label3 = new Label();
            txtV = new TextBox();
            grdTablaChi = new DataGridView();
            nroColumnaChi = new DataGridViewTextBoxColumn();
            LIChi = new DataGridViewTextBoxColumn();
            LSChi = new DataGridViewTextBoxColumn();
            foChi = new DataGridViewTextBoxColumn();
            feChi = new DataGridViewTextBoxColumn();
            C = new DataGridViewTextBoxColumn();
            Cac = new DataGridViewTextBoxColumn();
            grdTablaKS = new DataGridView();
            nroColumnaKS = new DataGridViewTextBoxColumn();
            LIKS = new DataGridViewTextBoxColumn();
            LSKS = new DataGridViewTextBoxColumn();
            foKS = new DataGridViewTextBoxColumn();
            feKS = new DataGridViewTextBoxColumn();
            PoKS = new DataGridViewTextBoxColumn();
            PeKS = new DataGridViewTextBoxColumn();
            PoAC = new DataGridViewTextBoxColumn();
            PeAC = new DataGridViewTextBoxColumn();
            difProb = new DataGridViewTextBoxColumn();
            maxDifProb = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)grdNormal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdTablaChi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdTablaKS).BeginInit();
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
            // btnGenerarHistograma
            // 
            btnGenerarHistograma.Location = new Point(139, 398);
            btnGenerarHistograma.Name = "btnGenerarHistograma";
            btnGenerarHistograma.Size = new Size(143, 26);
            btnGenerarHistograma.TabIndex = 6;
            btnGenerarHistograma.Text = "Generar Histograma";
            btnGenerarHistograma.UseVisualStyleBackColor = true;
            btnGenerarHistograma.Click += btnGenerarHistograma_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.Location = new Point(12, 427);
            label2.Name = "label2";
            label2.Size = new Size(194, 28);
            label2.TabIndex = 8;
            label2.Text = "Pruebas de Bondad";
            // 
            // btnCC
            // 
            btnCC.Location = new Point(12, 458);
            btnCC.Name = "btnCC";
            btnCC.Size = new Size(97, 40);
            btnCC.TabIndex = 9;
            btnCC.Text = "Calcular Chi Cuadrado";
            btnCC.UseVisualStyleBackColor = true;
            btnCC.Click += btnCC_Click;
            // 
            // btnKS
            // 
            btnKS.Location = new Point(12, 504);
            btnKS.Name = "btnKS";
            btnKS.Size = new Size(97, 40);
            btnKS.TabIndex = 10;
            btnKS.Text = "Calcular KS";
            btnKS.UseVisualStyleBackColor = true;
            btnKS.Click += btnKS_Click;
            // 
            // txtCC
            // 
            txtCC.Location = new Point(115, 468);
            txtCC.Name = "txtCC";
            txtCC.Size = new Size(100, 23);
            txtCC.TabIndex = 11;
            // 
            // txtKS
            // 
            txtKS.Location = new Point(115, 514);
            txtKS.Name = "txtKS";
            txtKS.Size = new Size(100, 23);
            txtKS.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(229, 471);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 13;
            label3.Text = "v =";
            // 
            // txtV
            // 
            txtV.Location = new Point(255, 468);
            txtV.Name = "txtV";
            txtV.Size = new Size(27, 23);
            txtV.TabIndex = 14;
            // 
            // grdTablaChi
            // 
            grdTablaChi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdTablaChi.Columns.AddRange(new DataGridViewColumn[] { nroColumnaChi, LIChi, LSChi, foChi, feChi, C, Cac });
            grdTablaChi.Location = new Point(290, 12);
            grdTablaChi.Name = "grdTablaChi";
            grdTablaChi.Size = new Size(647, 288);
            grdTablaChi.TabIndex = 15;
            // 
            // nroColumnaChi
            // 
            nroColumnaChi.HeaderText = "Nro";
            nroColumnaChi.Name = "nroColumnaChi";
            // 
            // LIChi
            // 
            LIChi.HeaderText = "Limite Inferior";
            LIChi.Name = "LIChi";
            // 
            // LSChi
            // 
            LSChi.HeaderText = "Limite Superior";
            LSChi.Name = "LSChi";
            // 
            // foChi
            // 
            foChi.HeaderText = "Frecuencia Observada";
            foChi.Name = "foChi";
            // 
            // feChi
            // 
            feChi.HeaderText = "Frecuencia Esperada";
            feChi.Name = "feChi";
            // 
            // C
            // 
            C.HeaderText = "C";
            C.Name = "C";
            // 
            // Cac
            // 
            Cac.HeaderText = "C(AC)";
            Cac.Name = "Cac";
            // 
            // grdTablaKS
            // 
            grdTablaKS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdTablaKS.Columns.AddRange(new DataGridViewColumn[] { nroColumnaKS, LIKS, LSKS, foKS, feKS, PoKS, PeKS, PoAC, PeAC, difProb, maxDifProb });
            grdTablaKS.Location = new Point(290, 306);
            grdTablaKS.Name = "grdTablaKS";
            grdTablaKS.Size = new Size(647, 257);
            grdTablaKS.TabIndex = 16;
            // 
            // nroColumnaKS
            // 
            nroColumnaKS.HeaderText = "Nro";
            nroColumnaKS.Name = "nroColumnaKS";
            // 
            // LIKS
            // 
            LIKS.HeaderText = "Limite Inferior";
            LIKS.Name = "LIKS";
            // 
            // LSKS
            // 
            LSKS.HeaderText = "Limite Superior";
            LSKS.Name = "LSKS";
            // 
            // foKS
            // 
            foKS.HeaderText = "Frecuencia Observada";
            foKS.Name = "foKS";
            // 
            // feKS
            // 
            feKS.HeaderText = "Frecuencia Esperada";
            feKS.Name = "feKS";
            // 
            // PoKS
            // 
            PoKS.HeaderText = "Prob Observada";
            PoKS.Name = "PoKS";
            // 
            // PeKS
            // 
            PeKS.HeaderText = "Prob Esperada";
            PeKS.Name = "PeKS";
            // 
            // PoAC
            // 
            PoAC.HeaderText = "PoAC";
            PoAC.Name = "PoAC";
            // 
            // PeAC
            // 
            PeAC.HeaderText = "PeAC";
            PeAC.Name = "PeAC";
            // 
            // difProb
            // 
            difProb.HeaderText = "| PoAC - PeAC |";
            difProb.Name = "difProb";
            // 
            // maxDifProb
            // 
            maxDifProb.HeaderText = "max(| PoAC - PeAC |)";
            maxDifProb.Name = "maxDifProb";
            // 
            // Normal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 558);
            Controls.Add(grdTablaKS);
            Controls.Add(grdTablaChi);
            Controls.Add(txtV);
            Controls.Add(label3);
            Controls.Add(txtKS);
            Controls.Add(txtCC);
            Controls.Add(btnKS);
            Controls.Add(btnCC);
            Controls.Add(label2);
            Controls.Add(btnGenerarHistograma);
            Controls.Add(cmbIntervalos);
            Controls.Add(label1);
            Controls.Add(grdNormal);
            Name = "Normal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Normal[me, de]";
            Load += Normal_Load;
            ((System.ComponentModel.ISupportInitialize)grdNormal).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdTablaChi).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdTablaKS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdNormal;
        private DataGridViewTextBoxColumn Nro;
        private DataGridViewTextBoxColumn RND;
        private Label label1;
        private ComboBox cmbIntervalos;
        private Button btnGenerarHistograma;
        private Label label2;
        private Button btnCC;
        private Button btnKS;
        private TextBox txtCC;
        private TextBox txtKS;
        private Label label3;
        private TextBox txtV;
        private DataGridView grdTablaChi;
        private DataGridViewTextBoxColumn nroColumnaChi;
        private DataGridViewTextBoxColumn LIChi;
        private DataGridViewTextBoxColumn LSChi;
        private DataGridViewTextBoxColumn foChi;
        private DataGridViewTextBoxColumn feChi;
        private DataGridViewTextBoxColumn C;
        private DataGridViewTextBoxColumn Cac;
        private DataGridView grdTablaKS;
        private DataGridViewTextBoxColumn nroColumnaKS;
        private DataGridViewTextBoxColumn LIKS;
        private DataGridViewTextBoxColumn LSKS;
        private DataGridViewTextBoxColumn foKS;
        private DataGridViewTextBoxColumn feKS;
        private DataGridViewTextBoxColumn PoKS;
        private DataGridViewTextBoxColumn PeKS;
        private DataGridViewTextBoxColumn PoAC;
        private DataGridViewTextBoxColumn PeAC;
        private DataGridViewTextBoxColumn difProb;
        private DataGridViewTextBoxColumn maxDifProb;
    }
}