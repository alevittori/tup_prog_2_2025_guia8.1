using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    internal class Expositor : Persona
    {
        public string PapelProtagonico { get; set; }
        public Expositor(string nombre, string dni, string papelProtagonico) : base(nombre, dni)
        {
            PapelProtagonico = papelProtagonico;
        }
    }
}
