using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio12.Interfaces
{
    public class Operaciones
    {
        public static void Encabezado(string titulo)
        {
            Console.WriteLine($" =================================================\n{titulo}\n =================================================");
        }
        public static void Espaciado()
        {
            Console.WriteLine(" =================================================");
        }
        public static int getEntero(string prefijo)
        {
            int respuesta;
            bool correcto;

            string numeroTexto = getTextoPantalla(prefijo);
            correcto = int.TryParse(numeroTexto, out respuesta);
            if (!correcto)
            {
                Console.WriteLine("\n Ingresa un número válido");
                Console.ReadKey();
                Console.Clear();
                Interfaz.MenuPrincipal();
            }

            return respuesta;
        }
        public static string getTextoPantalla(string prefijo)
        {
            Console.Write(prefijo);
            return Console.ReadLine();
        }
    }
}
