namespace TP2
{
    partial class Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            cmbDistribucion = new ComboBox();
            txtTamaño = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtA = new TextBox();
            txtB = new TextBox();
            txtMedia = new TextBox();
            txtDE = new TextBox();
            btnGenerar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 0;
            label1.Text = "Cantidad de Numeros";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 41);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 1;
            label2.Text = "Distribucion";
            // 
            // cmbDistribucion
            // 
            cmbDistribucion.FormattingEnabled = true;
            cmbDistribucion.Location = new Point(143, 38);
            cmbDistribucion.Name = "cmbDistribucion";
            cmbDistribucion.Size = new Size(121, 23);
            cmbDistribucion.TabIndex = 2;
            cmbDistribucion.SelectionChangeCommitted += cmbDistribucion_SelectionChangeCommitted;
            // 
            // txtTamaño
            // 
            txtTamaño.Location = new Point(143, 9);
            txtTamaño.Name = "txtTamaño";
            txtTamaño.Size = new Size(121, 23);
            txtTamaño.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.Location = new Point(3, 76);
            label3.Name = "label3";
            label3.Size = new Size(120, 28);
            label3.TabIndex = 4;
            label3.Text = "Parametros";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 127);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 5;
            label4.Text = "Limite Inferior(A)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 156);
            label5.Name = "label5";
            label5.Size = new Size(102, 15);
            label5.TabIndex = 6;
            label5.Text = "Limite Superior(B)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(76, 196);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 7;
            label6.Text = "Media";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(4, 229);
            label7.Name = "label7";
            label7.Size = new Size(112, 15);
            label7.TabIndex = 8;
            label7.Text = "Desviacion Estandar";
            // 
            // txtA
            // 
            txtA.Location = new Point(133, 124);
            txtA.Name = "txtA";
            txtA.Size = new Size(100, 23);
            txtA.TabIndex = 9;
            // 
            // txtB
            // 
            txtB.Location = new Point(133, 153);
            txtB.Name = "txtB";
            txtB.Size = new Size(100, 23);
            txtB.TabIndex = 10;
            // 
            // txtMedia
            // 
            txtMedia.Location = new Point(133, 188);
            txtMedia.Name = "txtMedia";
            txtMedia.Size = new Size(100, 23);
            txtMedia.TabIndex = 11;
            // 
            // txtDE
            // 
            txtDE.Location = new Point(133, 226);
            txtDE.Name = "txtDE";
            txtDE.Size = new Size(100, 23);
            txtDE.TabIndex = 12;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(12, 284);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(96, 38);
            btnGenerar.TabIndex = 13;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 334);
            Controls.Add(btnGenerar);
            Controls.Add(txtDE);
            Controls.Add(txtMedia);
            Controls.Add(txtB);
            Controls.Add(txtA);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtTamaño);
            Controls.Add(cmbDistribucion);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Ingreso de Parametros";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbDistribucion;
        private TextBox txtTamaño;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtMedia;
        private TextBox txtDE;
        private Button btnGenerar;
    }
}
