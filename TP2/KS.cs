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

        public static (double, List<double>, List<double>, List<double>, List<double>,
            List<double>, List<double>, List<double>, List<double>,
            List<double>, List<double>) KSUniforme(List<double> rnd, int N)
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

            //intento de llenar el DataGridView con los valores de la matriz de intervalos
            // el vector intervalos por cada fila i tiene los dos valores de los limites
            List<double> limInf = new List<double>();
            List<double> limSup = new List<double>();

            for (int i = 0; i < cantIntervalos; i++)
            {
                limInf.Add(Math.Round(intervalos[i, 0], 4));
                limSup.Add(Math.Round(intervalos[i, 1], 4));
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

            //vectores para mostrar las prob esperadas y esperadas acumuladas
            List<double> probEsperadas = new List<double>();
            List<double> probEspAC = new List<double>();
            double peAC = 0;
            for (int i = 0; i < cantIntervalos; i++)
            {
                probEsperadas.Add(Math.Round(pe, 4));
                peAC += Math.Round(pe, 4);
                probEspAC.Add(peAC);
            }

            //vectores para mostrar las prob observadas y observadas acumuladas
            List<double> probObservadas = new List<double>();
            List<double> probObsAC = new List<double>();

            //vectores para mostrar el ks y el max ks
            List<double> ksUnitarios = new List<double>();
            List<double> maxKSv = new List<double>();

            double peAc = 0.0;
            double poAc = 0.0;

            double maxKS = 0.0;

            for (int i = 0; i < fo.Count; i++)
            {
                //calcular la prob obs de cada elemento y agrego al vector
                double po = fo[i] / N;
                probObservadas.Add(Math.Round(po, 4));

                //acumulamos probabilidades
                poAc = po + poAc;
                peAc = pe + peAc;

                probObsAC.Add(Math.Round(poAc, 4));

                double ks = Math.Abs(poAc - peAc);
                ksUnitarios.Add(Math.Round(ks, 4));

                //comparo con el maxKS actual
                if (maxKS < ks)
                {
                    maxKS = ks;
                }
                maxKSv.Add(Math.Round(maxKS, 4));



            }

            //return Math.Round(maxKS, 4);
            return (Math.Round(maxKS, 4), limInf, limSup, fo, fe, probEsperadas, probEspAC,
                probObservadas, probObsAC, ksUnitarios, maxKSv);
        }

        public static (double, List<double>, List<double>,
            List<double>, List<double>, List<double>, List<double>,
            List<double>, List<double>, List<double>, List<double>) KSExponencial(List<double> rnd, int N, double me)
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

            //intento de llenar el DataGridView con los valores de la matriz de intervalos
            // el vector intervalos por cada fila i tiene los dos valores de los limites
            List<double> limInfv = new List<double>();
            List<double> limSupv = new List<double>();

            for (int i = 0; i < cantIntervalos; i++)
            {
                limInfv.Add(Math.Round(intervalos[i, 0], 4));
                limSupv.Add(Math.Round(intervalos[i, 1], 4));
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

            //vector para mostrar frecuencias esperadas = probEsperada * N
            List<double> fe = new List<double>();
            for (int i = 0; i < pr_e.Count; i++)
            {
                fe.Add(Math.Round((pr_e[i] * N), 4));
            }

            //vectores para mostrar las probabilidades unitarias, acumuladas, ks, max ks

            List<double> poUnitarios = new List<double>();
            List<double> poAcumulados = new List<double>();
            List<double> peUnitarios = new List<double>();
            List<double> peAcumulados = new List<double>();
            List<double> ksExp = new List<double>();
            List<double> maxKSExp = new List<double>();

            double peAc = 0.0;
            double poAc = 0.0;

            double maxKS = 0.0;

            for (int i = 0; i < cantIntervalos; i++)
            {
                //calcular la prob obs de cada elemento
                double po = fo[i] / rnd.Count();
                poUnitarios.Add(Math.Round(po, 4));

                double pe = pr_e[i];
                peUnitarios.Add(Math.Round(pe, 4));

                //acumulamos probabilidades
                poAc = po + poAc;
                poAcumulados.Add(Math.Round(poAc, 4));
                peAc = pe + peAc;
                peAcumulados.Add(Math.Round(peAc, 4));




                double ks = Math.Abs(poAc - peAc);
                ksExp.Add(Math.Round(ks, 4));


                //comparo con el maxKS actual
                if (maxKS < ks)
                {
                    maxKS = ks;
                }
                maxKSExp.Add(Math.Round(maxKS, 4));
            }

            return (Math.Round(maxKS, 4), limInfv, limSupv, fo, fe, poUnitarios, peUnitarios,
                poAcumulados, peAcumulados, ksExp, maxKSExp);
            //return maxKS;
        }

        public static (double, List<double>, List<double>,
            List<double>, List<double>, List<double>, List<double>,
            List<double>, List<double>, List<double>, List<double>) KSNormal(List<double> rnd, int N, double me, double de)
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

            //intento de llenar el DataGridView con los valores de la matriz de intervalos
            // el vector intervalos por cada fila i tiene los dos valores de los limites
            List<double> limInfv = new List<double>();
            List<double> limSupv = new List<double>();

            for (int i = 0; i < cantIntervalos; i++)
            {
                limInfv.Add(Math.Round(intervalos[i, 0], 4));
                limSupv.Add(Math.Round(intervalos[i, 1], 4));
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

            //vector para mostrar frecuencias esperadas = probEsperada * N
            List<double> fe = new List<double>();
            for (int i = 0; i < pr_e.Count; i++)
            {
                fe.Add(Math.Round((pr_e[i]*N), 4));
            }

            //vectores para mostrar las probabilidades unitarias, acumuladas, ks, max ks

            List<double> poUnitarios = new List<double>();
            List<double> poAcumulados = new List<double>();
            List<double> peUnitarios = new List<double>();
            List<double> peAcumulados = new List<double>();
            List<double> ksNormal = new List<double>();
            List<double> maxKSNormal = new List<double>();

            double peAc = 0.0;
            double poAc = 0.0;

            double maxKS = 0.0;


            for (int i = 0; i < cantIntervalos; i++)
            {
                //calcular la prob obs de cada elemento
                double po = fo[i] / rnd.Count();
                poUnitarios.Add(Math.Round(po, 4));

                double pe = pr_e[i];
                peUnitarios.Add(Math.Round(pe, 4));

                //acumulamos probabilidades
                poAc = po + poAc;
                poAcumulados.Add(Math.Round(poAc, 4));
                peAc = pe + peAc;
                peAcumulados.Add(Math.Round(peAc, 4));


                

                double ks = Math.Abs(poAc - peAc);
                ksNormal.Add(Math.Round(ks, 4));


                //comparo con el maxKS actual
                if (maxKS < ks)
                {
                    maxKS = ks;
                }
                maxKSNormal.Add(Math.Round(maxKS, 4));
            }

            

            return (Math.Round(maxKS, 4), limInfv, limSupv, fo, fe,
                poUnitarios, peUnitarios, poAcumulados, peAcumulados, ksNormal, maxKSNormal);
            //return maxKS;
        }


    }

}
