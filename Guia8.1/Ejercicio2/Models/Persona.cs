using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    internal class Persona:IComparable<Persona>
    {
        protected string dni;
        protected string nombre;

        public string DNI { get { return dni; } protected set { } }
        public string Nombre { get { return nombre; } protected set { } }

        public Persona(string nombre, string dni) 
        {
            DNI = dni;
            Nombre = nombre;
        
        }

        public override string ToString()
        {
            return $"{Nombre} (DNI: {DNI}). ";
        }

        public int CompareTo(Persona other)
        {
            if (other == null) return -1 ;
            return this.DNI.CompareTo(other.DNI) ;
        }

    }
}
