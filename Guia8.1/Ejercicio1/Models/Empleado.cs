using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public abstract class Empleado:IComparable<Empleado>
    {
        public string DNI { get; protected set; }
        public string Nombre { get; protected set; }

        public Empleado() { }
        public Empleado(string dni, string nombre)
        {
            //DNI = dni;
            //Nombre = nombre;
            
            DNI = string.IsNullOrWhiteSpace(dni) ? throw new ArgumentException("DNI inválido") : dni;
            Nombre = string.IsNullOrWhiteSpace(nombre) ? throw new ArgumentException("Nombre inválido") : nombre;
        

        }

        public abstract decimal CalcularImporteAPagar();
        public abstract string[] GenerarRecibo();


        public override string ToString()
        {
            return $"{Nombre} - DNI: {DNI}";
        }

        public int CompareTo(Empleado other)
        {
            if(other == null) return -1 ;
            return this.DNI.CompareTo(other.DNI);

            //si tuviera otra comparacion en la que pueden ser iguales, podria implemetar una segunda comparacion con otra propiedad
            //int dniComp = this.DNI.CompareTo(other.DNI);
           // return dniComp != 0 ? dniComp : this.Nombre.CompareTo(other.Nombre);
        }

       


    }
}

