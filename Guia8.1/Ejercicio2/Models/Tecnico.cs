using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    internal class Tecnico
    {
        public string Cargo { get; set; }
        public string CUIT {  get; private set; }
        public string Nombre { get; private set; }

        public Tecnico() { }

        public Tecnico(string cuit, string nombre, string cargo)
        {
            CUIT = cuit;
            Cargo = cargo;
            Nombre = nombre;
        }





    }
}
