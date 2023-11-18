using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio12.Interfaces
{
    public class Interfaz
    {
        public static int[] Respuesta = new int[101];
        public static int contador = 0;
        public static int contadorDespuesEliminar = 0; //Agregamos un contador para seguir insertando datos después
                                                       //de eliminar uno
        public static int MenuPrincipal()
        {
            Operaciones.Encabezado(" Encuestas de Calidad");
            Console.WriteLine(" 1: Realizar encuesta\n " +
                "2: Ver datos registrados\n " +
                "3: Eliminar un dato\n " +
                "4: Ordenar datos de menor a mayor\n " +
                "5: Salir");
            Operaciones.Espaciado();
            int opcion = Operaciones.getEntero(" Ingrese una opción: ");
            return opcion;
        }
        public static int RealizarEncuesta()
        {
            if (contadorDespuesEliminar > 0) //Hacemos un "for" para crear un arreglo con 1 elemento mayor
            {
                int[] ArregloDespuesEliminar = new int[Respuesta.Length + 1];
                for (int i = 0; i < Respuesta.Length; i++)//Se pone como límite al arreglo anterior porque se quieren
                                                          //agregar más espacios y copiar todos los valores del anterior arreglo,
                                                          //si se pone el nuevo, faltarían datos en el arreglo anterior y daría error
                {
                    ArregloDespuesEliminar[i] = Respuesta[i];
                }
                Respuesta = ArregloDespuesEliminar;
                contadorDespuesEliminar--; //Se reduce dicho contador para no influir en la inserción de los demás
                                           //datos y evitar interrumpir el siguiente "if"
            }
            if (contador == Respuesta.Length)
            {
                int[] NuevaRespuesta = new int[Respuesta.Length + 3];
                for (int i = 0; i < Respuesta.Length; i++)
                {
                    NuevaRespuesta[i] = Respuesta[i];
                }
                Respuesta = NuevaRespuesta;
            }
            Operaciones.Encabezado(" Nivel de Satisfacción");
            Console.WriteLine(" ¿Qué tan satisfecho está con la\n atención de nuestra tienda?\n " +
                "1: Nada satisfecho\n " +
                "2: No muy satisfecho\n " +
                "3: Tolerable\n " +
                "4: Satisfecho\n " +
                "5: Muy satisfecho");
            Operaciones.Espaciado();
            int opcion = Operaciones.getEntero(" Ingrese una opción: ");
            if (opcion > 0 && opcion < 6)
            {
                Respuesta[contador] = opcion;
                contador++;
            }
            Console.Clear();
            Operaciones.Encabezado(" Nivel de Satisfacción");
            Console.WriteLine("\n\n ¡Gracias por participar!\n\n");
            Operaciones.Espaciado();
            Console.WriteLine(" Presione una tecla para\n regresar al menú...");
            Console.ReadKey();
            return 0;
        }
        public static int DatosRegistrados()
        {
            Operaciones.Encabezado(" Ver Datos Registrados");
            int espacio = 0, NadaSatis = 0, NoMuySatis = 0, Tole = 0, Satis = 0, MuySatis = 0;
            for (int i = 0; i < contador; i++)
            {
                Console.Write($" [{Respuesta[i]}] ");
                if (i == espacio + 4)
                {
                    Console.WriteLine(" ");
                    espacio += 5;
                }
                if (Respuesta[i] == 1) NadaSatis++;
                if (Respuesta[i] == 2) NoMuySatis++;
                if (Respuesta[i] == 3) Tole++;
                if (Respuesta[i] == 4) Satis++;
                if (Respuesta[i] == 5) MuySatis++;
            }
            Console.WriteLine("\n");
            Console.WriteLine(" {0} personas: Nada satisfecho", NadaSatis);
            Console.WriteLine(" {0} personas: No muy satisfecho", NoMuySatis);
            Console.WriteLine(" {0} personas: Tolerable", Tole);
            Console.WriteLine(" {0} personas: Satisfecho", Satis);
            Console.WriteLine(" {0} personas: Muy satisfecho", MuySatis);
            Console.WriteLine(" ");
            Operaciones.Espaciado();
            Console.WriteLine(" Presione una tecla para regresar...");
            Console.ReadKey();
            return 0;
        }
        public static int EliminarDatos()
        {
            Operaciones.Encabezado(" Eliminar un Dato");
            int espacio = 0;
            Console.WriteLine("");
            for (int i = 0; i < contador; i++)
            {
                if (i == 0 || i < 10) Console.Write($" 00{i}:[{Respuesta[i]}] ");
                if (i == 10 || (i > 10 && i < 100)) Console.Write($" 0{i}:[{Respuesta[i]}] ");
                if (i == 100 || (i > 100 && i < 1000)) Console.Write($" {i}:[{Respuesta[i]}] ");
                if (i == espacio + 4)
                {
                    Console.WriteLine(" ");
                    espacio+=5;
                }
            }
            espacio = 0;//Se reinicia el espacio para que cumpla en el otro "for"
            Console.WriteLine("\n");
            Operaciones.Espaciado();
            int posicion = Operaciones.getEntero(" Ingrese la posición a eliminar: ");
            int TamañoNuevo = contador -1;
            int[] ArregloNuevo = new int[TamañoNuevo];
            Operaciones.Espaciado();
            Console.WriteLine("");
            for (int i = 0; i < ArregloNuevo.Length; i++)//Se coloca como límite en el "for" al arreglo nuevo porque
                                                         //se quiere eliminar un valor
            {
                if (posicion > i) ArregloNuevo[i] = Respuesta[i];
                else ArregloNuevo[i] = Respuesta[i + 1];
            }
            for (int i = 0; i < ArregloNuevo.Length; i++)
            {
                if (i == 0 || i < 10) Console.Write($" 00{i}:[{ArregloNuevo[i]}] ");
                if (i == 10 || (i > 10 && i < 100)) Console.Write($" 0{i}:[{ArregloNuevo[i]}] ");
                if (i == 100 || (i > 100 && i < 1000)) Console.Write($" {i}:[{ArregloNuevo[i]}] ");
                if (i == espacio + 4)
                {
                    Console.WriteLine(" ");
                    espacio += 5;
                }
            }
            Respuesta = ArregloNuevo;
            contador = ArregloNuevo.Length;
            contadorDespuesEliminar++; //Aumentamos en 1 al contador después de eliminar para que
                                       //pueda ingresar en la condicional "if" y se aumente 1 elemento en el arreglo
            Console.WriteLine("\n");
            Operaciones.Espaciado();
            Console.WriteLine(" Presione una tecla para regresar...");
            Console.ReadKey();
            return 0;
        }
        public static int OrdenarMenoraMayor()
        {
            int espacio = 0;
            Operaciones.Encabezado(" Ordenar Datos");
            Console.WriteLine("");
            for (int i = 0; i < contador; i++)//Va "contador" y no "Respuesta.Length" porque no se va a ordenar todos los datos
                                              //del arreglo ni se va a cambiar el tamaño de este, solo se ordenará los valores
                                              //colocados en el arreglo y la cantidad de elementos usados en este, está en "contador"
            {
                Console.Write($" [{Respuesta[i]}] ");
                if (i == espacio + 4)
                {
                    Console.WriteLine(" ");
                    espacio += 5;
                }
            }
            Console.WriteLine("\n");
            Operaciones.Encabezado(" Datos Ordenados: ");
            Console.WriteLine("");
            for (int i = 0; i < contador; i++)//Se pone como límite la cantidad de elementos (el normal) porque este
                                                      //"for" irá avanzando de uno en uno (valor por valor)
            {
                for (int j = 0; j < contador - 1; j++)//Se coloca -1 al límite del "for" porque se va comparando
                                                              //entre dos elementos por lo que no comparará el valor final
                                                              //con el que le sigue ya que este último no existe. Porque irá avanzando de dos en dos
                {
                    if (Respuesta[j] > Respuesta[j + 1])
                    {
                        int aux = Respuesta[j + 1];
                        Respuesta[j + 1] = Respuesta[j];
                        Respuesta[j] = aux;
                    }
                }
            }
            espacio = 0;
            for (int i = 0; i < contador; i++)
            {
                Console.Write($" [{Respuesta[i]}] ");
                if (i == espacio + 4)
                {
                    Console.WriteLine(" ");
                    espacio += 5;
                }
            }
            Console.WriteLine("\n");
            Operaciones.Espaciado();
            Console.WriteLine(" Presione una tecla para regresar...");
            Console.ReadKey();
            return 0;
        }
    }
}
