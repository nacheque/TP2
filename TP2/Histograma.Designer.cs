namespace TP2
{
    partial class Histograma
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            chartHistograma = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chartHistograma).BeginInit();
            SuspendLayout();
            // 
            // chartHistograma
            // 
            chartArea2.Name = "ChartArea1";
            chartHistograma.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartHistograma.Legends.Add(legend2);
            chartHistograma.Location = new Point(12, 12);
            chartHistograma.Name = "chartHistograma";
            chartHistograma.Size = new Size(776, 426);
            chartHistograma.TabIndex = 4;
            chartHistograma.Text = "chart1";
            // 
            // Histograma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chartHistograma);
            Name = "Histograma";
            Text = "Histograma";
            Load += Histograma_Load;
            ((System.ComponentModel.ISupportInitialize)chartHistograma).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartHistograma;
    }
}