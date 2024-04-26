﻿using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2
{
    public partial class Exponencial : Form
    {
        private double me;
        private int n;
        public Exponencial(double me, int n)
        {
            InitializeComponent();
            this.me = me;
            this.n = n;
        }

        private void Poisson_Load(object sender, EventArgs e)
        {
            List<double> aleatorios = GenerarNumerosAleatoriosExponenciales(me, n);

            grdExponencial.AllowUserToAddRows = false;

            grdExponencial.Rows.Clear();
            for (int i = 0; i < aleatorios.Count; i++)
            {
                grdExponencial.Rows.Add((i + 1).ToString(), aleatorios[i]);
            }

            List<int> intervalos = new List<int> { 10, 12, 16, 23 };
            cmbIntervalos.DataSource = intervalos;
            cmbIntervalos.SelectedIndex = -1;
        }

        static List<double> GenerarNumerosAleatoriosExponenciales(double media, int cantidad)
        {
            List<double> numerosAleatorios = new List<double>();
            Random random = new Random();

            for (int i = 0; i < cantidad; i++)
            {
                double u = random.NextDouble(); // Generar un número aleatorio entre 0 y 1
                double numeroAleatorio = -media * Math.Log(1 - u); // Fórmula de la distribución exponencial inversa
                numeroAleatorio = Math.Round(numeroAleatorio, 4);
                numerosAleatorios.Add(numeroAleatorio);
            }

            return numerosAleatorios;
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
                foreach (DataGridViewRow fila in grdExponencial.Rows)
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
            foreach (DataGridViewRow fila in grdExponencial.Rows)
            {
                if (!fila.IsNewRow && fila.Cells[1].Value != null)
                {
                    datos.Add(double.Parse(fila.Cells[1].Value.ToString()));
                }
            }

            //ChiCuadradoTest cc = new ChiCuadradoTest(datos, "Uniforme");
            (double cc, int v) = ChiCuadradoTest.ChiCuadradoExponencial(datos, this.me);
            txtCC.Text = cc.ToString();
        }

        private void btnKS_Click(object sender, EventArgs e)
        {
            // Genero una lista para guardar los numeros aleatorios
            List<double> datos = new List<double>();

            //Llenamos la lista con los datos de la tabla que ya tienen distribucion uniforme
            foreach (DataGridViewRow fila in grdExponencial.Rows)
            {
                if (!fila.IsNewRow && fila.Cells[1].Value != null)
                {
                    datos.Add(double.Parse(fila.Cells[1].Value.ToString()));
                }
            }


            //ChiCuadradoTest cc = new ChiCuadradoTest(datos, "Uniforme");
            double cc = KS.KSExponencial(datos, datos.Count, this.me);
            txtKS.Text = cc.ToString();
        }
    }
}
