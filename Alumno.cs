using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Escuela_
{
    internal class Alumno
    {
        private string name;
        private float n1, n2, n3;

        public Alumno(string name, float n1, float n2, float n3)
        {
            this.name = name;
            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
        }
        public string Nombre() => name;
        public float Nota1() => n1;
        public float Nota2() => n2;
        public float Nota3() => n3;

        public float PromedioTLS() => (n1 + n2 + n3*2) / 4;

        public bool Aprobado() => PromedioTLS() >= 13;
    }
}
