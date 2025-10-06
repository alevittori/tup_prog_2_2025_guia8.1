using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Jornalero : Empleado
    {
        public int HorasTrabajadas { get; set; }
        public decimal ImportePorHora { get; set; }
        public decimal Retenciones { get; set; }

        public Jornalero(string dni, string nombre, int horas, decimal importeHora, decimal retenciones)
            : base(dni, nombre)
        {
            HorasTrabajadas = horas;
            ImportePorHora = importeHora;
            Retenciones = retenciones;
        }

        public override decimal CalcularSueldo()
        {
            return (HorasTrabajadas * ImportePorHora) - Retenciones;
        }
    }
}
