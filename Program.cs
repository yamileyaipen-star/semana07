using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace semana07
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;
        static public void titulo()
        {
            Console.WriteLine("**************************");
            Console.WriteLine("SIsitema de gestion de notas ");
            Console.WriteLine("***************************");
        }
        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("Alconzo la capacidad máxima");
                return;
            }
            Console.Write("ingresar el nombre del estudiante: ");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("ingrese la nota [0-20]: ");
                nota = double.Parse(Console.ReadLine());
                if (nota >= 0 && nota <= 20)
                {
                    break;
                }
                Console.WriteLine("Error, volver a ingresar la nota [0-20]: ");
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
            Console.WriteLine("Registro con éxito...!!");
        }
        static public void Buscar_estudiante()
        {
            Console.WriteLine("******Buscar estudiante******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrador");
                return;
            }
            Console.WriteLine("Ingresar nombre a buscar: ");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine("Estudiante encontrado: ");
                    Console.WriteLine(nombres[i] + "tiene " + notas[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
                Console.WriteLine("Estudiante no encontrado...");
        }
        static public void Modificar_nota()
        {
            Console.WriteLine("******Modificar nota del estudiante******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.Write("Ingresar nombre del estudiante: ");
            string nom_buscar = Console.ReadLine().ToLower();
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i] + "tiene " + notas[i]);
                    double nueva_nota;
                    while (true)
                    {
                        Console.Write("ingrese la nueva nota [0-20]: ");
                        nueva_nota = double.Parse(Console.ReadLine());
                        if (nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("nota modificada con éxito...!!");
                            return;
                        }
                        Console.WriteLine("Nota fuera de rango [0-20]");
                    }
                }
            }
            Console.WriteLine("Estudiante no encontrado...");
        }
        static public void Mostrar()
        {
            Console.WriteLine("******Listador original*******");
            if (contador == 0)
            {
                Console.WriteLine ("No hay estudiantes registrados");
                return;
            }
            Console.WriteLine("\tnombre \t\tnotas");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine("\t"+ nombres[i] + "\t\t" + notas[i]);
            }
        }
        static public void Burbuja()
        {
            Console.WriteLine("******ordenamineto ascendente*********");
            double temp_nota;
            string temp_nombre;
            for (int i = 0; i < contador; i++)
            {
                for (int j=0;j< contador - 1 -i; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        temp_nota = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_nota;
                        temp_nombre = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombre;
                    }
                }
            }
            Mostrar();
        }
        static public void Seleccion()
        {
            Console.WriteLine("\n***Ordenamiento por selección descendente***");
            double temp_nota;
            string temp_nombre;
            int posicionMayor;
            for (int i = 0; i < contador - 1; i++)
            {
                posicionMayor = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[posicionMayor])
                    {
                        posicionMayor = j;
                    }
                }
                temp_nota = notas[i];
                notas[i] = notas[posicionMayor];
                notas[posicionMayor] = temp_nota;
                temp_nombre = nombres[i];
                nombres[i] = nombres[posicionMayor];
                nombres[posicionMayor] = temp_nombre;
            }
            Mostrar();
        }
        static public void nota_max_promedio_min()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            double max = notas[0];
            double min = notas[0];
            double suma = 0;
            for (int i = 0; i < contador; i++)
            {
                if (notas[i] > max)
                    max = notas[i];
                if (notas[i] < min)
                    min = notas[i];
                suma += notas[i];
            }
            double promedio = suma / contador;
            Console.WriteLine("Nota máxima: " + max);
            Console.WriteLine("Nota mínima: " + min);
            Console.WriteLine("Promedio: " + promedio);
        }
        static void Main(string[] args)
        {
            titulo();
            int opc = 0;
            while (opc != 6)
            {
                Console.WriteLine("***********************");
                Console.WriteLine("[1] registrar al estudiante");
                Console.WriteLine("[2] Buscar estudiamnte");
                Console.WriteLine("[3] Modificar la nota");
                Console.WriteLine("[4] Mostrar lista sin ordenar");
                Console.WriteLine("[5] Ordenar con burbuja");
                Console.WriteLine("[6] ordenar con soleccion");
                Console.WriteLine("[7] salir");
                Console.WriteLine("ingresar la opcion: ");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Registrar_estudiante();
                        break;
                    case 2:
                        Buscar_estudiante();
                        break;
                    case 3:
                        Modificar_nota();
                        break;
                    case 4:
                        Mostrar();
                        break;
                    case 5:
                        Burbuja();
                        break;
                    case 6:
                        Seleccion();
                        break;
                    case 7:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta: ");
                        break;

                }
            }
        }
    }
}


 