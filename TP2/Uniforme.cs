using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TP2
{
    public partial class Uniforme : Form
    {
        private double a;
        private double b;
        private int n;
        private Chart chartHistograma;

        public Uniforme(double a, double b, int n)
        {
            InitializeComponent();
            this.a = a;
            this.b = b;
            this.n = n;
            //Iniciamos el histograma dentro del form
            InitializeChart();
        }

        //Configuramos el histograma
        private void InitializeChart()
        {
            chartHistograma = new Chart();
            chartHistograma.Size = new Size(600, 400);
            chartHistograma.Dock = DockStyle.Fill;

            ChartArea chartArea = new ChartArea();
            chartArea.Position = new ElementPosition(35, 15, 60, 50); // Ajusta el tamaño del ChartArea
            chartHistograma.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            chartHistograma.Series.Add(series);

            Controls.Add(chartHistograma);
        }

        private void GenerarHistograma(List<double> numerosAleatorios, int cantidadIntervalos)
        {
            // Limpiar el chart
            chartHistograma.Series[0].Points.Clear();

            // Calcular el rango de los datos
            double min = numerosAleatorios.Min();
            double max = numerosAleatorios.Max();
            double rango = max - min;

            // Calcular el ancho de cada intervalo
            double anchoIntervalo = rango / cantidadIntervalos;

            // Crear los intervalos y contar la frecuencia de cada uno
            Dictionary<double, int> frecuencias = new Dictionary<double, int>();
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                double intervaloInicio = min + i * anchoIntervalo;
                double intervaloFin = intervaloInicio + anchoIntervalo;
                frecuencias[intervaloInicio] = numerosAleatorios.Count(v => v >= intervaloInicio && v < intervaloFin);
            }

            // Agregar los puntos al Chart
            foreach (var kvp in frecuencias)
            {
                chartHistograma.Series[0].Points.AddXY(kvp.Key.ToString("0.00"), kvp.Value);
            }
        }

        private void Uniforme_Load(object sender, EventArgs e)
        {
            List<double> aleatorios = GenerarNumerosAleatorios(a, b, n);

            grdUniforme.AllowUserToAddRows = false;

            grdUniforme.Rows.Clear();
            for (int i = 0; i < aleatorios.Count; i++)
            {
                grdUniforme.Rows.Add((i + 1).ToString(), aleatorios[i]);
            }

            List<int> intervalos = new List<int> { 10, 12, 16, 23 };
            cmbIntervalos.DataSource = intervalos;
            cmbIntervalos.SelectedIndex = -1;

        }

        private List<double> GenerarNumerosAleatorios(double a, double b, int cantidad)
        {
            Random rand = new Random();
            List<double> numeros = new List<double>();

            for (int i = 0; i < cantidad; i++)
            {
                double numeroAleatorio = a + rand.NextDouble() * (b - a);
                numeroAleatorio = Math.Round(numeroAleatorio, 4);
                numeros.Add(numeroAleatorio);
            }

            return numeros;
        }

        private void btnGenerarHistograma_Click(object sender, EventArgs e)
        {
            if (cmbIntervalos.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese la cantidad de intervalos...");
            }
            else
            {
                List<double> datos = new List<double>();

                //Llenamos la lista con los datos de la tabla que ya tienen distribucion uniforme
                foreach (DataGridViewRow fila in grdUniforme.Rows)
                {
                    if (!fila.IsNewRow) // Verificar si la fila no es la fila de nuevo ingreso
                    {
                        // Suponiendo que la columna deseada es la primera columna (índice 0)
                        DataGridViewCell celda = fila.Cells[1];

                        // Verificar si la celda tiene un valor válido
                        if (celda.Value != null && celda.Value != DBNull.Value)
                        {
                            // Intentar convertir el valor de la celda a double
                            if (double.TryParse(celda.Value.ToString(), out double valor))
                            {
                                datos.Add(valor); // Agregar el valor a la lista
                            }
                            
                        }
                    }
                }

                GenerarHistograma(datos, int.Parse(cmbIntervalos.SelectedValue.ToString()));
            }
        }
    }
}
