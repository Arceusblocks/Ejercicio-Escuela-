using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Escuela_
{
    internal class Salon
    {
        private List<Alumno> alumnos = new List<Alumno>();
        private int codigoSalon;
        private int cantidadAlumnos;

        public int CodigoSalon => codigoSalon;
        public int CantidadAlumnos => cantidadAlumnos;

        public Salon(int codigo)
        {
            this.codigoSalon = codigo;
            this.cantidadAlumnos = 0;
        }

        public void Start()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine($"Salon: {codigoSalon}");
                Console.WriteLine($"Alumnos registrados {cantidadAlumnos}");
                Console.WriteLine("1.Ingresar Alumno:");
                Console.WriteLine("2.Remover Alumno");
                Console.WriteLine("3.Mostrar Alumno");
                Console.WriteLine("4.Cantidad de Aprobados");
                Console.WriteLine("5.Cantidad de Desaprobados");
                Console.WriteLine("6.Lista de Aprobados");
                Console.WriteLine("7.Lista de Desapronados");
                Console.WriteLine("8.Promedio General");
                Console.WriteLine("9.Salir");
                Console.WriteLine("Seleccione una opción:");

                int opcion =  int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: IngresarAlumno();break;
                    case 2: RemoverAlumno();break;
                    case 3: MostrarAlumno();break;
                    case 4: Console.WriteLine($"Aprobados: {CantidadAprobados()}");break;
                    case 5: Console.WriteLine($"Desaprobados: {CantidadDesaprobados()}");break;
                    case 6: MostrarAprobados();break;
                    case 7: MostrarDesaprobados();break;
                    case 8: Console.WriteLine($"Promedio general: {PromedioGeneral()}");break;
                    case 9: continuar = false;break;
                }

                if(continuar && opcion >= 1 && opcion <= 8)
                {
                    Console.WriteLine("Operación completada. Presione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }

        private void IngresarAlumno()
        {
            Console.WriteLine("Ingresa su nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingresar sus notas");
            float n1 = float.Parse(Console.ReadLine());
            float n2 = float.Parse(Console.ReadLine());
            float n3 = float.Parse(Console.ReadLine());

            alumnos.Add(new Alumno(nombre, n1, n2, n3));
            cantidadAlumnos++;
            Console.WriteLine($"Alumno agregado correctamente. Total: {CantidadAlumnos}");
        }

        private void RemoverAlumno()
        {
            {
                Console.Write("Ingrese el nombre del alumno a remover: ");
                string nombre = Console.ReadLine();
                bool encontrado = false;

                for (int i = 0; i < alumnos.Count; i++)
                {
                    if (alumnos[i].Nombre() == nombre)
                    {
                        alumnos.RemoveAt(i);
                        cantidadAlumnos--;
                        Console.WriteLine($"Alumno removido correctamente. Total: {cantidadAlumnos}");
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("Alumno no encontrado.");
                }
            }

        }
        private void MostrarAlumno()
        {
            Console.WriteLine("Lista de Alumnos:");
            for (int i = 0;i < alumnos.Count;i++)
            {
                Alumno alumno = alumnos[i];
                Console.WriteLine($"{alumno.Nombre()} - Notas: {alumno.Nota1()}, {alumno.Nota2()}, {alumno.Nota3()} - Promedio: {alumno.PromedioTLS() :F2} - {(alumno.Aprobado() ? "Aprobado" : "Desaprobado")}");
            }
        }

        private int CantidadAprobados()
        {
            int count = 0;
            for (int i = 0; i < alumnos.Count; i++)
            {
                if (alumnos[i].Aprobado()) count++;
            }
            return count;
        }

        private int CantidadDesaprobados() => cantidadAlumnos - CantidadAprobados();

        private void MostrarAprobados()
        {
            Console.WriteLine("Alumnos aprobados:");
            for (int i = 0; i < alumnos.Count; i++)
            {
                if (alumnos[i].Aprobado())
                {
                    Console.WriteLine($"{alumnos[i].Nombre()} - Promedio: {alumnos[i].PromedioTLS():F2}");
                }
            }

        }

        private void MostrarDesaprobados()
        {
            Console.WriteLine("Alumnos Desaprobados:");
            for (int i = 0; i< alumnos.Count; i++)
            {
                if (!alumnos[i].Aprobado())
                {
                    Console.WriteLine($"{alumnos[i].Nombre()} - Promedio: {alumnos[i].PromedioTLS() :F2}");
                }
            }
        }

        private int PromedioGeneral()
        {
            if (cantidadAlumnos == 0) return 0;

            int suma = 0;
            for (int i = 0;i < alumnos.Count;i++)
            {
                suma += (int)alumnos[i].PromedioTLS();
            }
            return suma / cantidadAlumnos; 
        }
    }
}
