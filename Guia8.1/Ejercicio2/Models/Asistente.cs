using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    internal class Asistente : Persona
    {
        public double ValorSeguro {  get; set; }
        public Asistente(string nombre, string dni, double valorSeguro) : base(nombre, dni)
        {
            ValorSeguro = valorSeguro;
        }
    }
}
