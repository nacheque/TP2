﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2
{
    public partial class Normal : Form
    {
        private double me;
        private double de;
        private int n;
        public Normal(double me, double de, int n)
        {
            InitializeComponent();
            this.me = me;
            this.de = de;
            this.n = n;
        }

        private void Normal_Load(object sender, EventArgs e)
        {
            List<double> aleatorios = GenerarNumerosAleatoriosNormales(me, de, n);

            grdNormal.AllowUserToAddRows = false;

            grdNormal.Rows.Clear();
            for (int i = 0; i < aleatorios.Count; i++)
            {
                grdNormal.Rows.Add((i + 1).ToString(), aleatorios[i]);
            }

            List<int> intervalos = new List<int> { 10, 12, 16, 23 };
            cmbIntervalos.DataSource = intervalos;
            cmbIntervalos.SelectedIndex = -1;
        }

        static List<double> GenerarNumerosAleatoriosNormales(double media, double desviacionEstandar, int cantidad)
        {
            List<double> numeros = new List<double>();
            Random random = new Random();

            for (int i = 0; i < cantidad; i++)
            {
                double u1 = random.NextDouble(); // Generar dos números aleatorios entre 0 y 1
                double u2 = random.NextDouble();

                double z0 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2); // Aplicar Box-Muller
                double z1 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

                double numero = media + desviacionEstandar * z0; // Aplicar transformación de media y desviación estándar
                numero = Math.Round(numero, 4);
                numeros.Add(numero);
            }

            if (cantidad % 2 != 0)
            {
                double u = random.NextDouble();
                double z = Math.Sqrt(-2.0 * Math.Log(u)) * Math.Cos(2.0 * Math.PI * u); // Aplicar Box-Muller

                double numero = media + desviacionEstandar * z; // Aplicar transformación de media y desviación estándar

                numero = Math.Round(numero, 4);

                numeros.Add(numero);
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
                foreach (DataGridViewRow fila in grdNormal.Rows)
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
            foreach (DataGridViewRow fila in grdNormal.Rows)
            {
                if (!fila.IsNewRow && fila.Cells[1].Value != null)
                {
                    datos.Add(double.Parse(fila.Cells[1].Value.ToString()));
                }
            }

            List<double> limInf = new List<double>();
            List<double> limSup = new List<double>();
            List<int> fo = new List<int>();
            List<double> fe = new List<double>();
            List<double> cV = new List<double>();
            List<double> cAC = new List<double>();

            (double cc, int v, limInf, limSup, fo, fe,
                cV, cAC) = ChiCuadradoTest.ChiCuadradoNormal(datos, this.me, this.de);
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
                grdTablaChi.Rows[i].Cells["nroColumnaChi"].Value = i + 1;
            }
        }

        private void btnKS_Click(object sender, EventArgs e)
        {
            // Genero una lista para guardar los numeros aleatorios
            List<double> datos = new List<double>();

            //Llenamos la lista con los datos de la tabla que ya tienen distribucion uniforme
            foreach (DataGridViewRow fila in grdNormal.Rows)
            {
                if (!fila.IsNewRow && fila.Cells[1].Value != null)
                {
                    datos.Add(double.Parse(fila.Cells[1].Value.ToString()));
                }
            }


            List<double> limInfv = new List<double>();
            List<double> limSupv = new List<double>();
            List<double> fo = new List<double>();
            List<double> fe = new List<double>();
            List<double> poUnitarios = new List<double>();
            List<double> poAcumulados = new List<double>();
            List<double> peUnitarios = new List<double>();
            List<double> peAcumulados = new List<double>();
            List<double> ksNormal = new List<double>();
            List<double> maxKSNormal = new List<double>();

            (double cc, limInfv, limSupv, fo, fe,
                poUnitarios, peUnitarios, poAcumulados, peAcumulados, ksNormal,
                maxKSNormal) = KS.KSNormal(datos, this.n, this.me, this.de);
            txtKS.Text = cc.ToString();

            if (grdTablaKS.Rows.Count < limInfv.Count)
            {
                grdTablaKS.Rows.Add(limInfv.Count - grdTablaKS.Rows.Count);
            }

            for (int i = 0; i < limSupv.Count; i++)
            {
                grdTablaKS.Rows[i].Cells["LIKS"].Value = limInfv[i].ToString();
                grdTablaKS.Rows[i].Cells["LSKS"].Value = limSupv[i].ToString();
                grdTablaKS.Rows[i].Cells["foKS"].Value = fo[i].ToString();
                grdTablaKS.Rows[i].Cells["feKS"].Value = fe[i].ToString();
                grdTablaKS.Rows[i].Cells["PoKS"].Value = poUnitarios[i].ToString();
                grdTablaKS.Rows[i].Cells["PeKS"].Value = peUnitarios[i].ToString();
                grdTablaKS.Rows[i].Cells["PoAC"].Value = poAcumulados[i].ToString();
                grdTablaKS.Rows[i].Cells["PeAC"].Value = peAcumulados[i].ToString();
                grdTablaKS.Rows[i].Cells["difProb"].Value = ksNormal[i].ToString();
                grdTablaKS.Rows[i].Cells["maxDifProb"].Value = maxKSNormal[i].ToString();
                grdTablaKS.Rows[i].Cells["nroColumnaKS"].Value = i+1;
            }
        }
    }
}
