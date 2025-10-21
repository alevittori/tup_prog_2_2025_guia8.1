using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    internal class Expositor : Persona, IExportable
    {
        public string PapelProtagonico { get; set; }
        public Expositor(string nombre, string dni, string papelProtagonico) : base(nombre, dni)
        {
            PapelProtagonico = papelProtagonico;
        }

        public override string ToString()
        {
            return $"{Nombre}, {PapelProtagonico}";
        }
        public void Leer(string[] linea) // sería como  un importar
        {
            DNI = linea[0];
            Nombre = linea[1];
            PapelProtagonico = linea[2];


           
        }

        public string Escribir() // sería como un exportar
        {
            return $"{DNI};{Nombre};{PapelProtagonico}";
        }
    }
}
