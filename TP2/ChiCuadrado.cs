using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Security.Permissions;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ChiCuadradoTest
{
    private List<double> datos;
    private string distribucion;

    public ChiCuadradoTest(List<double> datos, string distribucion)
    {
        this.datos = datos;
        this.distribucion = distribucion;

    }

    public static int CalcularTamañoIntervalo(int N)
    {
        double raiz = Math.Sqrt(N);

        int primoCercano = EncontrarPrimoCercanoMenor((int)Math.Floor(raiz) + 1);

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

    public static (double, int) ChiCuadradoUniforme(List<double> rnd, int N)
    {
        int cantIntervalos = CalcularTamañoIntervalo(N);

        // frecuencia esperada de la distribucion uniforme
        List<int> fe = new List<int>();
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


        List<int> fo = new List<int>();

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
        double chiCuadrado = 0;

        //se acumula cada calculo del chi que se realiza para cada fo y fe
        for (int i = 0; i < cantIntervalos; i++)
        {
            chiCuadrado = chiCuadrado + Math.Pow(fo[i] - fe[i], 2) / fe[i];
        }

        return (Math.Round(chiCuadrado, 4), cantIntervalos - 1);
    }

    public static (double, int) ChiCuadradoNormal(List<double> rnd, double media, double de)
    {
        int N = rnd.Count;

        int cantIntervalos = CalcularTamañoIntervalo(N);

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
                intervalos[i, 0] = minimo - 1;
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

        intervalos[cantIntervalos - 1, 1] = intervalos[cantIntervalos - 1, 1] + 1;

        double marcaClase;

        //Calculo la frecuencia esperada para la distribucion normal
        // =(EXP{-0,5*((MarcaClase-Media)/DesvStd)^2})/(DesvStd*RAIZ(2*PI)))*(limiteSup-LimiteInf)

        List<double> fe = new List<double>();

        for (int i = 0; i < cantIntervalos; i++)
        {
            marcaClase = (intervalos[i, 0] + intervalos[i, 1]) / 2;

            // Calculamos la probabilidad para cada intervalo
            double poi = ((Math.Pow(Math.E, -0.5 * Math.Pow(((marcaClase - media) / de), 2))) / (de * Math.Sqrt(Math.PI * 2))) * (intervalos[i, 1] - intervalos[i, 0])
;
            // Multiplicamos N por la probabilidad de cada intervalo y lo guardamos en el vector de fe
            //fe[i] = poi * N;
            fe.Add(poi * N);
        }

        //DEPURACION

        List<double> feAcum = new List<double>();
        List<double[,]> intervalosNuevos = new List<double[,]>();

        double feSum = 0;
        double limiteInferior = 0;
        double limiteSuperior;
        bool huboCambioIntervalos = false;
        double ultimoLS = 0;

        //AGRUPAMIENTO
        for (int i = 0; i < cantIntervalos; i++)
        {
            if (fe[i] < 5)
            {
                feSum = feSum + fe[i];
                huboCambioIntervalos = true;
                if (limiteInferior == 0)
                {
                    limiteInferior = intervalos[i, 0];
                }
                else
                {
                    if (limiteInferior < intervalos[i, 0] && feSum >= 5)
                    {
                        limiteSuperior = intervalos[i, 1];
                        feAcum.Add(feSum);
                        intervalosNuevos.Add(new double[,] { { limiteInferior, limiteSuperior } });
                        feSum = 0;
                        limiteInferior = 0;
                    }
                }
            }
            else
            {
                if (feSum == 0)
                {
                    feAcum.Add(fe[i]);
                    intervalosNuevos.Add(new double[,] { { intervalos[i, 0], intervalos[i, 1] } });
                }
                else
                {
                    feAcum.Add(fe[i] + feSum);
                    intervalosNuevos.Add(new double[,] { { limiteInferior, intervalos[i, 1] } });
                    feSum = 0;
                    limiteInferior = 0;
                }
            }

            if (i == (cantIntervalos - 1) && feSum > 0)
            {
                ultimoLS = intervalos[i, 1];
            }
        }

        if(ultimoLS != 0)
        {
            feAcum[feAcum.Count - 1] += feSum;
            double[,] ultimaMatriz = intervalosNuevos[intervalosNuevos.Count - 1];
            int ultimaFila = ultimaMatriz.GetLength(0) - 1;
            ultimaMatriz[ultimaFila, 1] = ultimoLS;
        }

        if (huboCambioIntervalos)
        {
            fe = feAcum;
            int cantidadIntervalosNuevos = intervalosNuevos.Count;
            double[,] matrizIntervalos = new double[cantidadIntervalosNuevos, 2];
            for (int i = 0; i < cantidadIntervalosNuevos; i++)
            {
                matrizIntervalos[i, 0] = intervalosNuevos[i][0, 0]; // Límite inferior
                matrizIntervalos[i, 1] = intervalosNuevos[i][0, 1]; // Límite superior
            }
            intervalos = matrizIntervalos;
            cantIntervalos = cantidadIntervalosNuevos;
        }

        List<int> fo = new List<int>();

        // Agregar n valores en 0 a la lista
        for (int i = 0; i < cantIntervalos; i++)
        {
            fo.Add(0);
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < cantIntervalos; j++)
            {
                if (rnd[i] >= intervalos[j, 0] && (rnd[i] < intervalos[j, 1] || rnd[i] == intervalos[cantIntervalos -1, 1]))
                {
                    fo[j]++;
                }
            }
        }

        double chiCuadrado = 0;

        //DEPURACION
        


        //se acumula cada calculo del chi que se realiza para cada fo y fe
        for (int i = 0; i < cantIntervalos; i++)
        {
            chiCuadrado = chiCuadrado + Math.Pow(fo[i] - fe[i], 2) / fe[i];
        }

        //DEPURACION
        


        return (Math.Round(chiCuadrado, 4), cantIntervalos - 3);
    }

    public static (double, int) ChiCuadradoExponencial(List<double> rnd, double media)
    {
        int N = rnd.Count;

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

        List<int> fo = new List<int>();

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

        double probabilidadEsperada;
        double lambda = 1 / media;
        double e = Math.E;
        double limInf;
        double limSup;

        // frecuencia esperada de la distribucion exponencial negativa
        List<double> fe = new List<double>();
        for (int i = 0; i < cantIntervalos; i++)
        {
            limInf = intervalos[i, 0];
            limSup = intervalos[i, 1];
            probabilidadEsperada = (1 - Math.Pow(e, -lambda * limSup)) - (1 - Math.Pow(e, -lambda * limInf));
            fe.Add(probabilidadEsperada * N);
        }

        //terminado el for que recorre la matriz de intervalos acabamos con 2 vectores
        //fo[] y fe[] que representan las frecuancias de la lista
        double chiCuadrado = 0;

        //se acumula cada calculo del chi que se realiza para cada fo y fe
        for (int i = 0; i < cantIntervalos; i++)
        {
            chiCuadrado = chiCuadrado + Math.Pow(fo[i] - fe[i], 2) / fe[i];
        }

        return (Math.Round(chiCuadrado, 4), cantIntervalos - 2);

    }
    }