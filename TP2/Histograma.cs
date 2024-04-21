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
    public partial class Histograma : Form
    {
        private List<double> datos;
        private int intervalos;
        public Histograma(List<double> datos, int intervalos)
        {
            InitializeComponent();
            this.datos = datos;
            this.intervalos = intervalos;
        }

        private void Histograma_Load(object sender, EventArgs e)
        {
            double maximo = datos.Max();
            double minimo = datos.Min();
            double rango = maximo - minimo;
            int k = intervalos;
            double amplitud = Math.Round((rango / k), 4);

            chartHistograma.Titles.Add("Frecuencias de Datos");
            chartHistograma.Palette = ChartColorPalette.Pastel;

            //Este primer for rellena el arreglo de series con una cantidad de elementos
            //igual a la cantidad de intervalos seleccionada
            double limMinimo = 0;
            double limMaximo = 0;
            for (int i = 0; i < k; i++)
            {
                if (limMinimo == 0)
                {
                    limMinimo = minimo;
                    limMaximo = minimo + amplitud;
                }
                else
                {
                    limMinimo = limMaximo;
                    limMaximo = limMinimo + amplitud;
                }

                //titulos
                Series serie = chartHistograma.Series.Add("" + Math.Round(limMinimo, 4).ToString() + "-" + Math.Round(limMaximo, 4).ToString() + "");

                //Este segundo for toma los limites establecidos recien y recorre el arreglo
                //de datos contando cuantos valores hay de ese intervalo
                int cont = 0;
                for (int j = 0; j < datos.Count; j++)
                {
                    if (limMinimo <= datos[j] && datos[j] <= limMaximo)
                    {
                        cont++;
                    }
                }

                //cantidades
                serie.Label = cont.ToString();

                serie.Points.Add(cont);
            }
        }
    }
}
