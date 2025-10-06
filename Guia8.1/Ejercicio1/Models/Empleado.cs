using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public abstract class Empleado
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }

        public Empleado(string dni, string nombre)
        {
            DNI = dni;
            Nombre = nombre;
        }

        public abstract decimal CalcularSueldo();

        public override string ToString()
        {
            return $"{Nombre} - DNI: {DNI}";
        }
    }
}
