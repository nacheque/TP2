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

        private void btnCC_Click(object sender, EventArgs e)
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

            List<double> limInf = new List<double>();
            List<double> limSup = new List<double>();
            List<int> fo = new List<int>();
            List<int> fe = new List<int>();
            List<double> cV = new List<double>();
            List<double> cAC = new List<double>();
            //ChiCuadradoTest cc = new ChiCuadradoTest(datos, "Uniforme");
            (double cc, int v, limInf, limSup, fo, fe, cV, cAC) = 
                ChiCuadradoTest.ChiCuadradoUniforme(datos, n);

            txtCC.Text = cc.ToString();
            txtV.Text = v.ToString();

            if (grdTablaChi.Rows.Count < limInf.Count)
            {
                grdTablaChi.Rows.Add(limInf.Count - grdTablaChi.Rows.Count);
            }

            for (int i = 0; i < limInf.Count; i++)
            {
                grdTablaChi.Rows[i].Cells["LIChi"].Value = limInf[i].ToString();
                grdTablaChi.Rows[i].Cells["LSChi"].Value = limSup[i].ToString();
                grdTablaChi.Rows[i].Cells["foChi"].Value = fo[i].ToString();
                grdTablaChi.Rows[i].Cells["feChi"].Value = fe[i].ToString();
                grdTablaChi.Rows[i].Cells["C"].Value = cV[i].ToString();
                grdTablaChi.Rows[i].Cells["Cac"].Value = cAC[i].ToString();
                grdTablaChi.Rows[i].Cells["nroColumnaChi"].Value = i+1;
            }

        }

        private void btnKS_Click(object sender, EventArgs e)
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

            List<double> limInf = new List<double>();
            List<double> limSup = new List<double>();
            List<double> fo = new List<double>();
            List<double> fe = new List<double>();
            List<double> probEsperadas = new List<double>();
            List<double> probEspAC = new List<double>();
            List<double> probObservadas = new List<double>();
            List<double> probObsAC = new List<double>();
            List<double> ksUnitarios = new List<double>();
            List<double> maxKSv = new List<double>();

            (double ks, limInf, limSup, fo, fe, probEsperadas, probEspAC, 
                probObservadas, probObsAC, ksUnitarios, maxKSv) = KS.KSUniforme(datos, datos.Count);
            txtKS.Text = ks.ToString();

            if (grdTablaKS.Rows.Count < limInf.Count)
            {
                grdTablaKS.Rows.Add(limInf.Count - grdTablaKS.Rows.Count);
            }

            for (int i = 0; i < limInf.Count; i++)
            {
                grdTablaKS.Rows[i].Cells["LIKS"].Value = limInf[i].ToString();
                grdTablaKS.Rows[i].Cells["LSKS"].Value = limSup[i].ToString();
                grdTablaKS.Rows[i].Cells["foKS"].Value = fo[i].ToString();
                grdTablaKS.Rows[i].Cells["feKS"].Value = fe[i].ToString();
                grdTablaKS.Rows[i].Cells["PeKS"].Value = probEsperadas[i].ToString();
                grdTablaKS.Rows[i].Cells["PeAC"].Value = probEspAC[i].ToString();
                grdTablaKS.Rows[i].Cells["PoKS"].Value = probObservadas[i].ToString();
                grdTablaKS.Rows[i].Cells["PoAC"].Value = probObsAC[i].ToString();
                grdTablaKS.Rows[i].Cells["difProb"].Value = ksUnitarios[i].ToString();
                grdTablaKS.Rows[i].Cells["maxDifProb"].Value = maxKSv[i].ToString();
                grdTablaKS.Rows[i].Cells["nroColumnaKS"].Value = i+1;
            }
        }
    }
}
