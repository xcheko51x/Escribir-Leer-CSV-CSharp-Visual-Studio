using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscribirLeerCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            escribirCSV("sergio", "peralta", "Mexico");
            leerCSV();
        }

        static void escribirCSV(String nombre, String apellido, String pais)
        {
            String ruta = @"RUTA_DEL_ARCHIVO\NOMBRE_ARCHIVO.csv";
            String separador = ",";
            StringBuilder salida = new StringBuilder();

            String cadena = nombre + "," + apellido + ","  + pais;
            List<String> lista = new List<string>();
            lista.Add(cadena);

            for (int i = 0; i < lista.Count ; i++)
            salida.AppendLine(string.Join(separador, lista[i]));

            // CREA Y ESCRIBE EL ARCHIVO CSV
            //File.WriteAllText(ruta, salida.ToString());

            // AÑADE MAS LINEAS AL ARCHIVO CSV
            File.AppendAllText(ruta, salida.ToString());
        }

        static void leerCSV()
        {
            var reader = new StreamReader(File.OpenRead(@"RUTA_DEL_ARCHIVO\NOMBRE_ARCHIVO.csv"));
            List<String> lista = new List<string>();
            while (!reader.EndOfStream)
            {
                var linea = reader.ReadLine();
                var valores = linea.Split(',');
                for (int i = 0; i < valores.Length; i++)
                {
                    if ((i % 3) == 0)
                    {
                        Console.Write(valores[i] + "-" + valores[i + 1] + "-" + valores[i + 2]);
                    }
                    else
                    {
                        Console.WriteLine();
                    }

                }
            }
        }
    }
}