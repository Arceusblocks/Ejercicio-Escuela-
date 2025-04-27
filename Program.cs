using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Escuela_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Salon> salones = new List<Salon>();
            bool continuarPrograma = true;

            while (continuarPrograma)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE SALONES ===");
                Console.WriteLine("1. Crear nuevo salón");
                Console.WriteLine("2. Seleccionar salón existente");
                Console.WriteLine("3. Mostrar todos los salones");
                Console.WriteLine("4. Salir del programa");
                Console.Write("Seleccione una opción: ");

                int opcionPrincipal = int.Parse(Console.ReadLine());

                switch (opcionPrincipal)
                {
                    case 1: // Crear nuevo salón
                        Console.Write("Ingrese el código del nuevo salón: ");
                        int codigo = int.Parse(Console.ReadLine());
                        salones.Add(new Salon(codigo));
                        Console.WriteLine($"Salón {codigo} creado exitosamente.");
                        break;

                    case 2: // Seleccionar salón existente
                        if (salones.Count == 0)
                        {
                            Console.WriteLine("No hay salones creados.");
                        }
                        else
                        {
                            Console.WriteLine("Salones disponibles:");
                            for (int i = 0; i < salones.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. Salón {salones[i].CodigoSalon} - Alumnos: {salones[i].CantidadAlumnos}");
                            }

                            Console.Write("Seleccione un salón: ");
                            int seleccion = int.Parse(Console.ReadLine()) - 1;

                            if (seleccion >= 0 && seleccion < salones.Count)
                            {
                                salones[seleccion].Start();
                            }
                            else
                            {
                                Console.WriteLine("Selección inválida.");
                            }
                        }
                        break;

                    case 3: // Mostrar todos los salones
                        Console.WriteLine("=== LISTA DE SALONES ===");
                        foreach (var salon in salones)
                        {
                            Console.WriteLine($"Salón {salon.CodigoSalon} - Alumnos: {salon.CantidadAlumnos}");
                        }
                        break;

                    case 4: // Salir del programa
                        continuarPrograma = false;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (continuarPrograma && opcionPrincipal >= 1 && opcionPrincipal <= 3)
                {
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }
    }
}
