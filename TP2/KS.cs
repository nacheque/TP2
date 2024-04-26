using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class KS
    {
        public static int CalcularTamañoIntervalo(int N)
        {
            double raiz = Math.Sqrt(N);

            int primoCercano = EncontrarPrimoCercanoMenor((int)Math.Floor(raiz)+1);

            return primoCercano;
        }

        public static int EncontrarPrimoCercanoMenor(int numero)
        {
            // Buscar el primo más cercano menor que el número dado
            for (int i = numero; i >= 2; i++)
            {
                if (EsPrimo(i))
                {
                    return i;
                }
            }
            // Si no se encuentra ningún primo, se devuelve 1
            return 1;
        }

        public static bool EsPrimo(int numero)
        {
            if (numero <= 1)
                return false;
            for (int i = 2; i < numero; i += 1)
            {
                if (numero % i == 0)
                    return false;
            }
            return true;
        }

        public static double KSUniforme(List<double> rnd, int N)
        {
            int cantIntervalos = CalcularTamañoIntervalo(N);

            // frecuencia esperada de la distribucion uniforme
            List<double> fe = new List<double>();
            for (int i = 0; i < cantIntervalos; i++)
            {
                fe.Add(N / cantIntervalos);
            }
            

            // se crea una matriz de cantIntervalos filas y 2 columnas
            double[,] intervalos = new double[cantIntervalos, 2];

            double minimo = rnd.Min();
            double maximo = rnd.Max();
            double rango = maximo - minimo;
            double amplitud = rango / cantIntervalos;

            double supAnterior = 0;

            for (int i = 0; i < cantIntervalos; i++)
            {
                if (i == 0)
                {
                    intervalos[i, 0] = minimo;
                    intervalos[i, 1] = minimo + amplitud;
                    supAnterior = minimo + amplitud;
                }
                else
                {
                    intervalos[i, 0] = supAnterior;
                    intervalos[i, 1] = supAnterior + amplitud;
                    supAnterior = supAnterior + amplitud;
                }
            }


            List<double> fo = new List<double>();

            // Agregar n valores en 0 a la lista
            for (int i = 0; i < cantIntervalos; i++)
            {
                fo.Add(0);
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < cantIntervalos; j++)
                {
                    if (rnd[i] >= intervalos[j, 0] && rnd[i] < intervalos[j, 1])
                    {
                        fo[j]++;
                    }
                }
            }

            //terminado el for que recorre la matriz de intervalos acabamos con 2 vectores
            //fo[] y fe[] que representan las frecuancias de la lista

            //se calcula la probabilidad esperada para una dist uniforme
            double pe = fe[0] / N;

            //double pe = 0.01;

            double peAc = 0.0;
            double poAc = 0.0;

            double maxKS = 0.0;

            for (int i = 0; i < fo.Count; i++)
            {
                //calcular la prob obs de cada elemento
                double po = fo[i] / N;

                //acumulamos probabilidades
                poAc = po + poAc;
                peAc = pe + peAc;

                double ks = Math.Abs(poAc - peAc);

                //comparo con el maxKS actual
                if (maxKS < ks)
                {
                    maxKS = ks;
                }
            }

            //return Math.Round(maxKS, 4);
            return Math.Round(maxKS, 4);
        }

        public static double KSExponencial(List<double> rnd, int N, double me)
        {
            int cantIntervalos = CalcularTamañoIntervalo(N);

            // se crea una matriz de cantIntervalos filas y 2 columnas
            double[,] intervalos = new double[cantIntervalos, 2];

            double minimo = rnd.Min();
            double maximo = rnd.Max();
            double rango = maximo - minimo;
            double amplitud = rango / cantIntervalos;

            double supAnterior = 0;

            for (int i = 0; i < cantIntervalos; i++)
            {
                if (i == 0)
                {
                    intervalos[i, 0] = minimo;
                    intervalos[i, 1] = minimo + amplitud;
                    supAnterior = minimo + amplitud;
                }
                else
                {
                    intervalos[i, 0] = supAnterior;
                    intervalos[i, 1] = supAnterior + amplitud;
                    supAnterior = supAnterior + amplitud;
                }
            }

            List<double> fo = new List<double>();

            // Agregar n valores en 0 a la lista
            for (int i = 0; i < cantIntervalos; i++)
            {
                fo.Add(0);
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < cantIntervalos; j++)
                {
                    if (rnd[i] >= intervalos[j, 0] && rnd[i] < intervalos[j, 1])
                    {
                        fo[j]++;
                    }
                }
            }

            // Probabilidad esperada de la distribucion Exponencial
            List<double> pr_e = new List<double>();
            double lambda = 1 / me;
            double e = Math.E;
            double limInf;
            double limSup;
            for (int i = 0; i < cantIntervalos; i++)
            {
                limInf = intervalos[i, 0];
                limSup = intervalos[i, 1];
                pr_e.Add((1 - Math.Pow(e, -lambda * limSup)) - (1 - Math.Pow(e, -lambda * limInf)));
            }


            double peAc = 0.0;
            double poAc = 0.0;

            double maxKS = 0.0;

            for (int i = 0; i < fo.Count; i++)
            {
                //calcular la prob obs de cada elemento
                double po = fo[i] / N;
                double pe = pr_e[i];

                //acumulamos probabilidades
                poAc = po + poAc;
                peAc = pe + peAc;

                double ks = Math.Abs(poAc - peAc);

                //comparo con el maxKS actual
                if (maxKS < ks)
                {
                    maxKS = ks;
                }
            }

            return Math.Round(maxKS, 4);
            //return maxKS;
        }

        public static double KSNormal(List<double> rnd, int N, double me, double de)
        {
            int cantIntervalos = CalcularTamañoIntervalo(N);

            // se crea una matriz de cantIntervalos filas y 2 columnas
            double[,] intervalos = new double[cantIntervalos, 2];

            double minimo = rnd.Min();
            double maximo = rnd.Max();
            double rango = maximo - minimo;
            double amplitud = rango / cantIntervalos;

            double supAnterior = 0;

            for (int i = 0; i < cantIntervalos; i++)
            {
                if (i == 0)
                {
                    intervalos[i, 0] = minimo;
                    intervalos[i, 1] = minimo + amplitud;
                    supAnterior = minimo + amplitud;
                }
                else
                {
                    intervalos[i, 0] = supAnterior;
                    intervalos[i, 1] = supAnterior + amplitud;
                    supAnterior = supAnterior + amplitud;
                }
            }

            List<double> fo = new List<double>();

            // Agregar n valores en 0 a la lista
            for (int i = 0; i < cantIntervalos; i++)
            {
                fo.Add(0);
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < cantIntervalos; j++)
                {
                    if (rnd[i] >= intervalos[j, 0] && rnd[i] < intervalos[j, 1])
                    {
                        fo[j]++;
                    }
                }
            }

            // Probabilidad esperada de la distribucion Normal
            List<double> pr_e = new List<double>();
            double e = Math.E;
            double limInf;
            double limSup;
            for (int i = 0; i < cantIntervalos; i++)
            {
                limInf = intervalos[i, 0];
                limSup = intervalos[i, 1];
                double marcaClase = (limInf + limSup) / 2;
                double exponente = -Math.Pow((marcaClase - me), 2) / (2 * Math.Pow(de, 2));
                double denominador = de * Math.Sqrt(2 * Math.PI);
                double pe_i = Math.Pow(e, exponente) / denominador * (limSup-limInf);
                pr_e.Add(pe_i);
            }


            double peAc = 0.0;
            double poAc = 0.0;

            double maxKS = 0.0;


            for (int i = 0; i < cantIntervalos; i++)
            {
                //calcular la prob obs de cada elemento
                double po = fo[i] / rnd.Count();

                double pe = pr_e[i];

                //acumulamos probabilidades
                poAc = po + poAc;
                peAc = pe + peAc;


                

                double ks = Math.Abs(poAc - peAc);


                //comparo con el maxKS actual
                if (maxKS < ks)
                {
                    maxKS = ks;
                }
            }


            return Math.Round(maxKS, 4);
            //return maxKS;
        }


    }

}
