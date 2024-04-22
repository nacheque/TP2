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

    public static bool ChiCuadrado(List<double> rnd, string distribucion)
    {
        if(distribucion == "Uniforme")
        {
            //return ChiCuadradoUniforme(rnd, rnd.Count);
        }

        return true;
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

        return Math.Round(chiCuadrado, 4);
    }
}