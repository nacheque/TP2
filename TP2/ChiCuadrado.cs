using System;
using System.Collections.Generic;
using System.DirectoryServices;
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

        int primoCercano = EncontrarPrimoCercanoMenor((int)Math.Floor(raiz));

        return primoCercano;
    }

    public static int EncontrarPrimoCercanoMenor(int numero)
    {
        // Buscar el primo más cercano menor que el número dado
        for (int i = numero; i >= 2; i--)
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

    // esta funcion es para hacer la fe de la normal
    public static double CalcularDE(List<double> rnd, double media, int N)
    {
        double varianza;
        double acumulador = 0;
        for (int i = 0; i < rnd.Count; i += 1)
        {
            acumulador = acumulador + Math.Pow(rnd[i] - media, 2);
        }
        varianza = (1 / (N - 1)) * acumulador;

        return Math.Sqrt(varianza);
    }

    public static double ChiCuadradoUniforme(List<double> rnd, int N)
    {
        int cantIntervalos = CalcularTamañoIntervalo(N);

        // frecuencia esperada de la distribucion uniforme
        List<int> fe = new List<int>();
        for (int i = 0; i < cantIntervalos; i++)
        {
            fe.Add(N / cantIntervalos);
        }

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

        double chiCuadrado = 0;

        for (int i = 0; i < cantIntervalos; i++)
        {
            chiCuadrado = chiCuadrado + Math.Pow(fo[i] - fe[i], 2) / fe[i];
        }

        return Math.Round(chiCuadrado, 4);
    }

    public static double ChiCuadradoNormal(List<double> rnd)
    {
        int N = rnd.Count;

        int cantIntervalos = CalcularTamañoIntervalo(N);

        double media = rnd.Average();

        double de = CalcularDE(rnd, media, N);

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

        double e = Math.E;
        double marcaClase = 0;

        //Calculo la frecuencia esperada para la distribucion normal
        // =(EXP{-0,5*((MarcaClase-Media)/DesvStd)^2})/(DesvStd*RAIZ(2*PI)))*(limiteSup-LimiteInf)

        List<double> fe = new List<double>();

        for (int i = 0; i < cantIntervalos; i++)
        {
            marcaClase = (intervalos[i, 0] + intervalos[i, 1])/2;

            // Calculamos la probabilidad para cada intervalo
            double poi = ((Math.Pow(e, -0.5*Math.Pow(((marcaClase-media)/de), 2))) / de * Math.Sqrt(double.Pi * 2)) * (intervalos[i, 1] - intervalos[i, 0]);
            // Multiplicamos N por la probabilidad de cada intervalo y lo guardamos en el vector de fe
            fe[i] = poi * N;
        }

        List<double> feAcum = new List<double>();
        List<double[,]> intervalosNuevos = new List<double[,]>();

        double feSum = 0;
        double limiteInferior = 0;
        double limiteSuperior = 0;
        //ACA DEBE IR EL AGRUPAMIENTO
        for(int i = 0; i < cantIntervalos; i++)
        {
            if (fe[i] < 5)
            {
                feSum = feSum + fe[i];
            }
            if (limiteInferior == 0)
            {
                limiteInferior = intervalos[i, 1];
            }
            else
            {
                if(limiteInferior < intervalos[i, 0] && feSum >= 5)
                {
                    limiteSuperior = intervalos[i, 1];
                    feAcum.Add(feSum);
                    intervalosNuevos.Add(new double[,] { { limiteInferior, limiteSuperior } });
                    feSum = 0;
                    limiteInferior = 0;

                }
            }
            if(i+1 == cantIntervalos && feSum > 0)
            {
                feAcum[i - 1] += feSum;
                intervalosNuevos[i - 1][0, 1] = intervalos[i, 1];
            }
        }

        List<int> fo = new List<int>();



        return 3.14;
    }
}