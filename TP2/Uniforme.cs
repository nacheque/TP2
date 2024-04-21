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
        

        public Uniforme(double a, double b, int n)
        {
            InitializeComponent();
            this.a = a;
            this.b = b;
            this.n = n;
            
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
                //Genero una lista para guardar los numeros aleatorios
                List<double> datos = new List<double>();

                //Llenamos la lista con los datos de la tabla que ya tienen distribucion uniforme
                foreach (DataGridViewRow fila in grdUniforme.Rows)
                {
                    if (!fila.IsNewRow && fila.Cells[1].Value != null)
                    {
                        datos.Add(double.Parse(fila.Cells[1].Value.ToString()));
                    }
                }

                int intervalos = int.Parse(cmbIntervalos.SelectedValue.ToString());
                Histograma histograma = new Histograma(datos, intervalos);
                histograma.Show();
                
            }
        }
    }
}
