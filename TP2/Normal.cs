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

            return numeros;
        }
    }
}
