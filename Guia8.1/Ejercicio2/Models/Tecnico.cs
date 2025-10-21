using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    internal class Tecnico:IExportable, IComparable<Tecnico>
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

        public void Leer(string[] linea) // ya viene la linea como un arreglo de campos
        {
            CUIT = linea[0];
            Nombre = linea[1];
            Cargo = linea[2];
        }

        public string Escribir()
        {
            return $"{CUIT};{Nombre};{Cargo}"; // retornamos en formato CSV
        }

        public int CompareTo(Tecnico other)
        {
            if (other == null) { return -1; }
            return this.CUIT.CompareTo(other.CUIT);
        }
    }
}
