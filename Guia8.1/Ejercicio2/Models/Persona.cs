using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    internal class Persona
    {
        protected string dni;
        protected string nombre;

        public string DNI { get { return dni; } private set { } }
        public string Nombre { get { return nombre; } private set { } }

        public Persona(string nombre, string dni) 
        {
            DNI = dni;
            Nombre = nombre;
        
        }



    }
}
